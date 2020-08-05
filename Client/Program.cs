using Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MilitaryDogsTrainingClient.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {

        static async Task Main(string[] args)
        {
            // create a new ServiceCollection 
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            // create a new ServiceProvider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // For demo purposes: overall catch-all to log any exception that might 
            // happen to the console & wait for key input afterwards so we can easily 
            // inspect the issue.  
            try
            {
                // Run our IntegrationService containing all samples and
                // await this call to ensure the application doesn't 
                // prematurely exit.
                await serviceProvider.GetService<IIntegrationService>().Run();
            }
            catch (Exception generalException)
            {
                // log the exception
                var logger = serviceProvider.GetService<ILogger<Program>>();
                logger.LogError(generalException,
                    "An exception happened while running the integration service.");
            }

            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add loggers           
            serviceCollection.AddSingleton(new LoggerFactory());

            serviceCollection.AddLogging();
            serviceCollection.AddHttpClient("MilitaryDogsClient", httpClient=>
            {
                httpClient.BaseAddress = new Uri("http://localhost:53807");
                httpClient.Timeout = new TimeSpan(0, 0, 30);
                httpClient.DefaultRequestHeaders.Clear();
            }).ConfigurePrimaryHttpMessageHandler(handler =>
           new HttpClientHandler()
           {
               AutomaticDecompression = System.Net.DecompressionMethods.GZip
           });

            serviceCollection.AddHttpClient<MilitaryDogsClient>()
                    .ConfigurePrimaryHttpMessageHandler(handler =>
                       new HttpClientHandler()
                       {
                           AutomaticDecompression = System.Net.DecompressionMethods.GZip
                       });
            ;
            // register the integration service on our container with a 
            // scoped lifetime

            // CRUD 
            //  serviceCollection.AddScoped<IIntegrationService, CRUDService>();

            //  partial update 
            //   serviceCollection.AddScoped<IIntegrationService, PartialUpdateService>();

            // cancellation 
            //  serviceCollection.AddScoped<IIntegrationService, CancellationService>();

            //  HttpClientFactory 
         //   serviceCollection.AddScoped<IIntegrationService, HttpClientFactoryInstanceManagementService>();

            //  dealing with errors and faults demos
             serviceCollection.AddScoped<IIntegrationService, DealingWithErrorsAndFaultsService>();

            // For the custom http handlers demos
           //  serviceCollection.AddScoped<IIntegrationService, HttpHandlersService>();     
        }
    }
}
