using Marvin.StreamExtensions;
using Microsoft.AspNetCore.Mvc;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApplicationClient.Controllers
{
    public class TaskController:Controller
    {
        private IHttpClientFactory httpClientFactory;

        public TaskController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<ActionResult> Index()
        {
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(
             HttpMethod.Get,
             "api/Tasks");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            using (var response = await httpClient.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead))
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
                    var tasks = stream.ReadAndDeserializeFromJson<List<TaskDTO>>();
                    return View(tasks);
                
            }

        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
      
    }
}
