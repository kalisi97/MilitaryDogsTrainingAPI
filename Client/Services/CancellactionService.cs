using Marvin.StreamExtensions;
using MilitaryDogsTrainingModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Services
{
    /*
     * pomaze da se oslobode niti koje vise nisu potrebne
     * httpClient ce otkazati zahtev kada dodje do prekida
     * kako bi se dozvolilo otkazivanje nekog zadatka, prilikom slanja zahteva prosledjuje se token
     * kada se pozove metoda Cancel nad CancellationTokenSource koji je proizveo token, govorimo http klijentu da otkaze zahtev
     * kada se to desi, nastaje exception -> OperationCancelledException (ovaj exception nastaje i nakon isteka zahteva -> timeout)
     */
    public class CancellationService : IIntegrationService
    {
        private static HttpClient httpClient = new HttpClient(new
            HttpClientHandler()
        { AutomaticDecompression = System.Net.DecompressionMethods.GZip });

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public CancellationService()
        {
            httpClient.BaseAddress = new Uri("http://localhost:53807");
            httpClient.Timeout = new TimeSpan(0, 0, 5);
            httpClient.DefaultRequestHeaders.Clear();
        }
        public async System.Threading.Tasks.Task Run()
        {

            // cancellationTokenSource.CancelAfter(2000);
            //  await  GetTrainingCourseAndCancell(cancellationTokenSource.Token);

            await GetTrainingCourseAndHandleTimeout();
        }

        public async System.Threading.Tasks.Task GetTrainingCourseAndCancell(CancellationToken cancellationToken)
        {
            
                var request = new HttpRequestMessage(HttpMethod.Get, "api/TrainingCourse/GetById/2");
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
         
            //ovde cemo korsiti streamove
            try
            {
                using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead,
                           cancellationToken))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    response.EnsureSuccessStatusCode();
                    var trainingCourse = stream.ReadAndDeserializeFromJson<TrainingCourseDTO>();
                }
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"An operation was canceled with message: "+e.Message);
            }
        }


        public async System.Threading.Tasks.Task GetTrainingCourseAndHandleTimeout()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "api/TrainingCourse/GetById/2");
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            //ovde cemo korsiti streamove
            try
            {
                using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    response.EnsureSuccessStatusCode();
                    var trainingCourse = stream.ReadAndDeserializeFromJson<TrainingCourseDTO>();
                }
            }
            //iako je greska timeout exception, ovako je http klijent dizajniran, tako da ce se desiti operation cancelled exception
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"An operation was cancelled with message: " + e.Message);
            }
        }
    }
}
