using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using ApplicationClient.ViewModels;
using Marvin.StreamExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilitaryDogsTrainingAPI.Models;

namespace ApplicationClient.Controllers
{
    public class DogController : Controller
    {
        private IHttpClientFactory httpClientFactory;

        public DogController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(
             HttpMethod.Get,
             "api/Dog?PageNumber=1&PageSize=5");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            using (var response = await httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var dogs = stream.ReadAndDeserializeFromJson<List<DogDTO>>();
                return View(dogs);
            }
          
        } 
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Dog/id?id={id}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using(var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
               
                if (!response.IsSuccessStatusCode)
                {
                    var errorStream = await response.Content.ReadAsStreamAsync();
                    var error = errorStream.ReadAndDeserializeFromJson();
                    return View("Error");
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
                var stream = await response.Content.ReadAsStreamAsync();
                var dog = stream.ReadAndDeserializeFromJson<DogDTO>();
                UpdateDogViewModel dogForUpdate = new UpdateDogViewModel()
                {
                    DogId = id,
                    Breed = dog.Breed,
                    ChipNumber = dog.ChipNumber,
                    Age = dog.Age,
                    Gender = dog.Gender,
                    Name = dog.Name,
                    TrainingCourse = dog.TrainingCourse
                };
                return View(dogForUpdate);
            }
        }
        public async Task<ActionResult> Edit(UpdateDogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            DogForUpdateDTO forUpdateDTO = new DogForUpdateDTO
            {
                Id = model.DogId,
                Breed = model.Breed,
                ChipNumber = model.ChipNumber,
                Gender = model.Gender,
                Name = model.Name,
                TrainingCourse = model.TrainingCourse
            };
            var serializedDogForUpdate = JsonSerializer.Serialize(forUpdateDTO);
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(HttpMethod.Put, "api/Dog");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            request.Content = new StringContent(
                serializedDogForUpdate,
                System.Text.Encoding.Unicode,
                "application/json");


            using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {

                if (!response.IsSuccessStatusCode)
                {
                    var errorStream = await response.Content.ReadAsStreamAsync();
                    var error = errorStream.ReadAndDeserializeFromJson();
                    return View("Error");
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
                var stream = await response.Content.ReadAsStreamAsync();
                var dog = stream.ReadAndDeserializeFromJson<DogDTO>();
           
                return RedirectToAction("Index","Dog");
            }
        }
        public async Task<ActionResult> Remove(int id)
        {
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/Dog/dogId?dogId={id}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {

                if (!response.IsSuccessStatusCode)
                {
                    var errorStream = await response.Content.ReadAsStreamAsync();
                    var error = errorStream.ReadAndDeserializeFromJson();
                    return View("Error");
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
              
                return RedirectToAction("Index","Dog");
            }
        }
        [HttpGet]
        public async Task<ActionResult> CreateAsync()
        {
            GenderDropDownList();
            BreedDropDownList();
            await TrainingCourseDropDownListAsync();
            return View();
        }

        private async Task TrainingCourseDropDownListAsync(string course = null)
        {
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(HttpMethod.Get, "api/TrainingCourse");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                List<TrainingCourseDTO> courses = stream.ReadAndDeserializeFromJson<List<TrainingCourseDTO>>();
                List<string> courseNames = new List<string>();
                foreach (TrainingCourseDTO courseDTO in courses)
                {
                    courseNames.Add(courseDTO.Name);
                }
                ViewBag.TrainingCourse = new SelectList(courseNames.AsQueryable().AsNoTracking(), course);
            }


        }

        private void BreedDropDownList(string breed = null)
        {
            List<string> breeds = new List<string> { "Akita", "German shepard", "Belgian Malinois", "Sarplaninac"};
            ViewBag.Breed = new SelectList(breeds.AsQueryable().AsNoTracking(), breed);
        }

        private void GenderDropDownList(string gender = null)
        {
            List<string> genders = new List<string> { "Male", "Female" };
            ViewBag.Gender = new SelectList(genders.AsQueryable().AsNoTracking(), gender);
        }
        public async Task<ActionResult> Create(DogForCreationDTO model)
        {
           
            DogForCreationDTO dog = new DogForCreationDTO() 
            { 
            Breed = model.Breed,
            ChipNumber = model.ChipNumber,
            DateOfBirth = model.DateOfBirth,
            Gender = model.Gender,
            Name = model.Name,
            TrainingCourse = model.TrainingCourse
            };
            var serializedDogForCreation = JsonSerializer.Serialize(model);
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(HttpMethod.Post, "api/Dog");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            request.Content = new StringContent(
                serializedDogForCreation,
                System.Text.Encoding.Unicode,
                "application/json");

            using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                if (!response.IsSuccessStatusCode)
                {
                    var errorStream = await response.Content.ReadAsStreamAsync();
                    var error = errorStream.ReadAndDeserializeFromJson();
                    return View("Error");
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
                var stream = await response.Content.ReadAsStreamAsync();
                var createdDog = stream.ReadAndDeserializeFromJson<DogDTO>();

                return RedirectToAction("Index", "Dog");
            }
        }
    }
}