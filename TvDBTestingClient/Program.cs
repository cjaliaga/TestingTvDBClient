using System;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace TvDBTestingClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddLogging(configure =>
            {
                configure.AddConsole();
            });

            services.Configure<TvdbClientOptions>(options =>
            {
                options.ApiKey = "<API-KEY>";
                options.BaseAddress = "https://api.thetvdb.com";
            });

            services.AddTransient<TvDBAuthenticationHandler>();

            services.AddHttpClient("tvdb", (provider, client) =>
            {
                var options = provider.GetService<IOptions<TvdbClientOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);    
            })
            .AddHttpMessageHandler<TvDBAuthenticationHandler>();

            var provider = services.BuildServiceProvider();

            var factory = provider.GetService<IHttpClientFactory>();
            var client = factory.CreateClient("tvdb");
            var request = await client.GetAsync("/series/328724");

            var content = await request.Content.ReadAsStringAsync();
        }
    }
}
