using System;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using TvDBClient;

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

            services.AddTvDBClient(options =>
            {
                options.ApiKey = "<API-KEY>";
            });

            var provider = services.BuildServiceProvider();

            var tvdb = provider.GetService<TvDbClient>();

            var show = await tvdb.Series.GetAsync(328724);
        }
    }
}
