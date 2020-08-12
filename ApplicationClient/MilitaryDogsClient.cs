using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MilitaryDogsTrainingClient.Services
{
   public class MilitaryDogsClient
    {
        private HttpClient _client;


        public MilitaryDogsClient(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri("http://localhost:53807");
            Client.Timeout = new TimeSpan(0, 0, 30);
            Client.DefaultRequestHeaders.Clear();
        }

        public HttpClient Client { get => _client; set => _client = value; }
    }
}
