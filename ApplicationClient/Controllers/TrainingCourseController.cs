

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;

namespace ApplicationClient.Controllers
{
    public class TrainingCourseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TrainingCourseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient("MilitaryDogsClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "/api/TrainingCourse");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var trainingCourses = await JsonSerializer.DeserializeAsync<List<TrainingCourseDTO>>(responseStream);
                return View(new TrainingCourseViewModel(
                    await JsonSerializer.DeserializeAsync<List<TrainingCourseDTO>>(responseStream)));
            }

        }
    }
}
