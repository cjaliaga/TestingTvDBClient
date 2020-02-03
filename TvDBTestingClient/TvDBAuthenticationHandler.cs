using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace TvDBTestingClient
{
    class TvDBAuthenticationHandler : DelegatingHandler
    {
        private readonly TvdbClientOptions _options;
        private readonly ILogger<TvDBAuthenticationHandler> _logger;

        public TvDBAuthenticationHandler(IOptions<TvdbClientOptions> options, ILogger<TvDBAuthenticationHandler> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting request");

            var response = await base.SendAsync(request, cancellationToken);

            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _logger.LogInformation("Unauthorized request. Trying to get valid token.");

                // Get token from TvDB
                var authData = new AuthData
                {
                    ApiKey = _options.ApiKey
                };

                var authRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{_options.BaseAddress}/login"),
                    Content = new StringContent(JsonSerializer.Serialize(authData), Encoding.UTF8, "application/json")
                };

                var authResponse = await base.SendAsync(authRequest, cancellationToken);
                var token = await JsonSerializer.DeserializeAsync<TokenResponse>(await authResponse.Content.ReadAsStreamAsync());

                if(!authResponse.IsSuccessStatusCode || string.IsNullOrEmpty(token.Token))
                {
                    _logger.LogInformation("Failed to get token.");
                    return response;
                }

                _logger.LogInformation("Got valid token. Retrying request.");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token.Token);
                response = await base.SendAsync(request, cancellationToken);

                _logger.LogInformation($"Finished request");
                return response;
            }

            _logger.LogInformation($"Finished request");

            return response;
        }
    }
    
    internal class TokenResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }

    internal class AuthData
    {
        public string ApiKey { get; set; }
    }
}
