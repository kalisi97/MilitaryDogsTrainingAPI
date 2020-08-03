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
    public class CRUDService : IIntegrationService
    {
        private static HttpClient httpClient = new HttpClient();

        public CRUDService()
        {
            httpClient.BaseAddress = new Uri("http://localhost:53807");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             //specificarti ukoliko je potrebno da se obezbedi i application/xml, pri responsu proveriti koji je tip pa deserijalizovati
        }
        public async System.Threading.Tasks.Task Run()
        {
            //    await GetResource();
            // await GetResourceThroughHttpRequestMessage();
           // await CreateResource();
          //  await UpdateResource();
         await DeleteResource();
        }

        public async System.Threading.Tasks.Task GetResource()
        {
            var response = await httpClient.GetAsync("api/TrainingCourse");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            // da je bilo podesen prihvatljiv format application/xml, ovde bismo u if uslovu proveravali kog je tipa media type u headeru
            var trainingCourses = JsonConvert.DeserializeObject<IEnumerable<TrainingCourseDTO>>(content);
        }

        public async System.Threading.Tasks.Task GetResourceThroughHttpRequestMessage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/TrainingCourse");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var trainingCourses = JsonConvert.DeserializeObject<List<TrainingCourseDTO>>(content);
        }

        public async System.Threading.Tasks.Task CreateResource()
        {
            var trainingCourseToCreate = new TrainingCourseForCreationDTO
            {
                Description = "this is some description",
                Duration = 4,
                Name = "Search service 2"
            };
         
            var serializedTrainingCourseToCreate = JsonConvert.SerializeObject(trainingCourseToCreate);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/TrainingCourse");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content= new StringContent(serializedTrainingCourseToCreate);
            request.Content.Headers.ContentType =  new MediaTypeHeaderValue("application/json");
            var response = await httpClient.SendAsync(request);
          
            response.EnsureSuccessStatusCode();
            

            var content = await response.Content.ReadAsStringAsync();
            var createdCourse = JsonConvert.DeserializeObject<TrainingCourse>(content);
        }

        public async System.Threading.Tasks.Task UpdateResource()
        {
            var trainingCourseToUpdate = new TrainingCourseToUpdateDTO
            {
                Description = "this is some description",
                Duration = 4,
                Name = "BLA BLA"
            };
            var serializedTrainingCourseToUpdate = JsonConvert.SerializeObject(trainingCourseToUpdate);
            var request = new HttpRequestMessage(HttpMethod.Put, "api/TrainingCourse/id?id=14");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedTrainingCourseToUpdate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var updatedCourse = JsonConvert.DeserializeObject<TrainingCourse>(content);
        }

        public async System.Threading.Tasks.Task DeleteResource()
        {
          
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/TrainingCourse/id?id=16");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
          
        }

    }
}
