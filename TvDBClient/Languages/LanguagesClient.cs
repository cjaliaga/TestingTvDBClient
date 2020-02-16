using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TvDBClient.Models;

namespace TvDBClient.Languages
{
    internal class LanguagesClient : ILanguagesClient
    {
        private readonly HttpClient _client;

        internal LanguagesClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TvDbResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TvDbResponse<Language[]>>("/languages", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TvDbResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TvDbResponse<Language>>($"/languages/{languageId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
