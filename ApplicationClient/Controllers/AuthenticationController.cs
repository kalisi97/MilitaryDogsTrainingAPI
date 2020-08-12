using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Marvin.StreamExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;

namespace ApplicationClient.Controllers
{
    public class AuthenticationController : Controller
    {
    
      
        private readonly IHttpClientFactory httpClientFactory;

        public AuthenticationController(IHttpClientFactory httpClientFactory)
        {
         
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {   
                return View();      
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var serializedModel = JsonSerializer.Serialize(model);
                var httpClient = httpClientFactory.CreateClient("MilitaryDogsClient");
                var request = new HttpRequestMessage(
                 HttpMethod.Post,
                 "api/Authenticate/Login");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                request.Content = new StringContent(
                  serializedModel,
                  System.Text.Encoding.Unicode,
                  "application/json");
                using (var response = await httpClient.SendAsync(request,
                            HttpCompletionOption.ResponseHeadersRead))
                {
                    ApplicationUser user = null;
                    var stream = await response.Content.ReadAsStreamAsync();
                    response.EnsureSuccessStatusCode();
                   
                    if(model.Username == "admin")
                    {
                        var currentUser = stream.ReadAndDeserializeFromJson<Admin>();
                      
                        user = (Admin)currentUser;
                        return RedirectToAction("Index", "Home", new { message = user.UserName });

                    }
                    else
                    {
                        var currentUser = stream.ReadAndDeserializeFromJson<Instructor>();
                        Instructor userInstructor = (Instructor)currentUser;
                        return RedirectToAction("Index", "Home", new { message = userInstructor.FullName });

                    }

                }
            }
            catch (Exception ex)
            {

                return Unauthorized();
            }
        }
        
    }
}
