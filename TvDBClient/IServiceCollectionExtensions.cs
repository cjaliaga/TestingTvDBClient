using Microsoft.Extensions.Options;
using System;
using TvDBClient;
using TvDBClient.Authentication;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTvDBClient(this IServiceCollection services, Action<TvdbClientOptions> configureOptions)
        {
            services.AddOptions();

            services.Configure(configureOptions);

            services.AddScoped<TvDBTokenAccessor>();

            services.AddTransient<TvDBAuthenticationHandler>();

            services.AddHttpClient<TvDbClient>((provider, client) =>
            {
                var options = provider.GetService<IOptions<TvdbClientOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
            })
            .AddHttpMessageHandler<TvDBAuthenticationHandler>();

            return services;
        }
    }
}
