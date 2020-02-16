using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TvDBClient.Models;

namespace TvDBClient.Episodes
{
    internal class EpisodesClient : IEpisodesClient
    {
        private readonly HttpClient _client;

        public EpisodesClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TvDbResponse<EpisodeRecord>>($"/episodes/{episodeId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
