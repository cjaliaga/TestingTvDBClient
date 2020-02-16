using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(assembly: typeof(Program).Assembly)
                .Build();

            services.AddTvDBClient(options =>
            {
                options.ApiKey = configuration["ApiKey"];
            });

            var provider = services.BuildServiceProvider();

            var tvdb = provider.GetService<TvDbClient>();

            var show = await tvdb.Series.GetAsync(328724);
            show = await tvdb.Series.GetAsync(328724, keys =>
            {
                keys
                .IncludeAdded()
                .IncludeSeriesName()
                .IncludeBanner()
                .IncludeId()
                .IncludeAirsDayOfWeek();
            });

            var search = await tvdb.Search.SearchSeriesByNameAsync("sheldon");
            search = await tvdb.Search.SearchSeriesBySlugAsync("young-sheldon");

            var episode = await tvdb.Episodes.GetAsync(6794892);
        }
    }
}
