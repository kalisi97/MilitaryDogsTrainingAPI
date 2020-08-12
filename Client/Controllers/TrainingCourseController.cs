using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace MilitaryDogsTrainingClient.Controllers
{
   public class TrainingCourseController:Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TrainingCourseController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

       
    }
}
