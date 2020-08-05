using Client.Services;
using Marvin.StreamExtensions;
using MilitaryDogsTrainingClient.Services;
using MilitaryDogsTrainingModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class HttpClientFactoryInstanceManagementService : IIntegrationService
    {
       
        /*
         *  HttpClient implementira IDisposable pa je preporuka da se za
         *  deklarisanje i instanciranje objekta koristi using statement.
         *  Medjutim, kada se to radi, oslobadja se i HttpClientHandler takodje.
         *  HttpClientHandler je odgovoran za slanje zahteva.  Kada se oslobodi 
         *  putem Disposable, konekcija je zatvorenatakodje. Reinstanciranjem
         *  klijenta za sledeci zahtev, instancira se i novi HttpClientHandler,
         *  konekcija se ponovo otvara sto dovodi do sporog rada a moguce je da
         *  ne postoji dostupan soket. -> resenje je koriscenje HttpClientFactory
         */

        private readonly CancellationTokenSource cancellationTokenSource =
        new CancellationTokenSource();
        private readonly IHttpClientFactory httpClientFactory;
        private readonly MilitaryDogsClient client;
        public HttpClientFactoryInstanceManagementService(MilitaryDogsClient client,IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.client = client;
        }

        public async System.Threading.Tasks.Task Run()
        {
            //    await GetTrainingCoursesThroughHttpClientFactory(cancellationTokenSource.Token);
            await GetTrainingCoursesWithTypedClientFromHttpClientFactory(cancellationTokenSource.Token);
        }
        //1.nacin
        private async System.Threading.Tasks.Task GetTrainingCoursesThroughHttpClientFactory(CancellationToken cancellationToken)
        {
            //umesto kreiranja staticnog klijenta sada se klijent kreira iz HttpClientFactory
            var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
            var request = new HttpRequestMessage(
             HttpMethod.Get,
             "api/TrainingCourse");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            try
            {
                using (var response = await httpClient.SendAsync(request,
                       HttpCompletionOption.ResponseHeadersRead,
                       cancellationToken))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    response.EnsureSuccessStatusCode();
                    var trainingCourses = stream.ReadAndDeserializeFromJson<List<TrainingCourseDTO>>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //2. nacin
        private async System.Threading.Tasks.Task GetTrainingCoursesWithTypedClientFromHttpClientFactory(CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(
             HttpMethod.Get,
             "api/TrainingCourse");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            try
            {
                using (var response = await client.Client.SendAsync(request,
                       HttpCompletionOption.ResponseHeadersRead,
                       cancellationToken))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    response.EnsureSuccessStatusCode();
                    var trainingCourses = stream.ReadAndDeserializeFromJson<List<TrainingCourseDTO>>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
