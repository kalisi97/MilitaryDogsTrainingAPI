using Microsoft.AspNetCore.JsonPatch;
using MilitaryDogsTrainingModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class PartialUpdateService : IIntegrationService
    {
        private static HttpClient httpClient = new HttpClient();

        public PartialUpdateService()
        {
            httpClient.BaseAddress = new Uri("http://localhost:53807");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();
         //   httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async System.Threading.Tasks.Task Run()
        {
            await Patch();
        }

        //postoji shortcut PatchAsync
        public async System.Threading.Tasks.Task Patch()
        {
            //kreiranje dokumenta
            var patch = new JsonPatchDocument<TrainingCourseToUpdateDTO>();
            patch.Replace(m => m.Description, "Updated through patch");
           //serijalizacija dokumenta
            var serializedDocument = JsonConvert.SerializeObject(patch);
           //kreiranje zahteva i podesavanja
            var request = new HttpRequestMessage(HttpMethod.Patch, "api/TrainingCourse/courseId?courseId=17");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //kreiranje contenta
            request.Content = new StringContent(serializedDocument);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json-patch+json");
            //slanje zahteva
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync();
            var updatedCourse = JsonConvert.DeserializeObject<TrainingCourseToUpdateDTO>(content.Result);

        }

        //za bolje performanse moguce koristiti streamove:  ... content.ReadAsStreamAsync();
    }
}
