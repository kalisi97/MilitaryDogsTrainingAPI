using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApplicationClient.Models;
using System.Net.Http;
using MilitaryDogsTrainingAPI.Entities;
using System.Text.Json;
using MilitaryDogsTrainingAPI.Models;
using System.Net.Http.Headers;
using Marvin.StreamExtensions;
namespace ApplicationClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            this.httpClientFactory = httpClientFactory;
        }
        
        public async Task<IActionResult> Index(string message)
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
                var request = new HttpRequestMessage(
                 HttpMethod.Get,
                 "api/TrainingCourse");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
               
               using (var response = await httpClient.SendAsync(request,
                           HttpCompletionOption.ResponseHeadersRead))
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        response.EnsureSuccessStatusCode();
                        var trainingCourses = stream.ReadAndDeserializeFromJson<List<TrainingCourseDTO>>();
                    ViewBag.Courses = trainingCourses.ToList();
                    if (!String.IsNullOrEmpty(message))
                    {
                        ViewBag.User = message;
                    }
                    else
                    {
                        ViewBag.User = "";
                    }
                }
               
                  // TrainingCourseViewModel trainingCourses = new TrainingCourseViewModel(
                //  await JsonSerializer.DeserializeAsync<List<TrainingCourseDTO>>(responseStream));
             
              

                return View();

            }
            catch (Exception ex)
            {

                return View("Error");
            }
       
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}