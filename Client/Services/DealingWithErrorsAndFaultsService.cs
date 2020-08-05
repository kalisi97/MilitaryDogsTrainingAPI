using Marvin.StreamExtensions;
using MilitaryDogsTrainingClient.Services;
using MilitaryDogsTrainingModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Services
{
    public class DealingWithErrorsAndFaultsService : IIntegrationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private CancellationTokenSource _cancellationTokenSource =
            new CancellationTokenSource();
        private MilitaryDogsClient client;

        public DealingWithErrorsAndFaultsService(
            IHttpClientFactory httpClientFactory, MilitaryDogsClient client)
        {
            _httpClientFactory = httpClientFactory;
            this.client = client;
        }

        public async System.Threading.Tasks.Task Run()
        {
            //await GetTrainingCourseAndDealWithInvalidResponses(_cancellationTokenSource.Token);
            await PostTrainingCourseMovieAndHandleValdationErrors(_cancellationTokenSource.Token);
        }

        private async System.Threading.Tasks.Task GetTrainingCourseAndDealWithInvalidResponses(
            CancellationToken cancellationToken)
        {
         
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "api/TrainingCourse/GetById/29");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

                using (var response = await client.Client.SendAsync(request,
                    HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {

                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {

                            Console.WriteLine("The requested training course cannot be found.");
                            return;
                        }
                        else if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {

                            return;
                        }
                        response.EnsureSuccessStatusCode();
                    }

                    var stream = await response.Content.ReadAsStreamAsync();
                    var trainingCourse = stream.ReadAndDeserializeFromJson<TrainingCourseDTO>();
                } 
        }

        private async System.Threading.Tasks.Task PostTrainingCourseMovieAndHandleValdationErrors(
               CancellationToken cancellationToken)
        {


            var trainingCourseToCreate = new TrainingCourseForCreationDTO
            {
                Description = "YYY",
                Duration = 0,
                Name = "XXX"
            };

            var serializedCourseForCreation = JsonConvert.SerializeObject(trainingCourseToCreate);

            using (var request = new HttpRequestMessage(
                HttpMethod.Post,
                "api/TrainingCourse"))
            {
                request.Headers.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                request.Content = new StringContent(serializedCourseForCreation);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await client.Client.SendAsync(request,
                        HttpCompletionOption.ResponseHeadersRead,
                        cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                        {
                            var errorStream = await response.Content.ReadAsStreamAsync();
                            var validationErrors = errorStream.ReadAndDeserializeFromJson();
                            Console.WriteLine(validationErrors);
                            return;
                        }
                        else
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }

                    var stream = await response.Content.ReadAsStreamAsync();
                    var movie = stream.ReadAndDeserializeFromJson<TrainingCourseDTO>();
                }
            }
        }



    }
}
