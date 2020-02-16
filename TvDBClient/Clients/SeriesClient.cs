using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TvDBClient.Models;
using System.Linq;

namespace TvDBClient
{
    internal class SeriesClient : ISeriesClient
    {
        private readonly HttpClient _client;

        public SeriesClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<Actor[]>>($"/series/{seriesId}/actors", cancellationToken).ConfigureAwait(false);
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<Series>>($"/series/{seriesId}").ConfigureAwait(false);
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, Action<SerieKeys> configureKeys, CancellationToken cancellationToken = default)
        {
            var keys = new SerieKeys();
            configureKeys(keys);
            return await _client.GetJsonAsync<TvDbResponse<Series>>($"/series/{seriesId}/filter?keys={keys}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<TvDbResponse<EpisodeRecord[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<EpisodeRecord[]>>($"/series/{seriesId}/episodes?page={Math.Max(page, 1)}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<TvDbResponse<EpisodeRecord[]>> GetEpisodesAsync(
            int seriesId,
            int page,
            EpisodeQuery query,
            CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<EpisodeRecord[]>>($"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{query.ToQueryParams()}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<EpisodesSummary>>($"/series/{seriesId}/episodes/summary", cancellationToken).ConfigureAwait(false);
        }

        public async Task<IDictionary<string, IEnumerable<string>>> GetHeadersAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync($"/series/{seriesId}", cancellationToken);
            return response.Headers.ToDictionary(h => h.Key, x => x.Value);
        }

        public async Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<Image[]>>($"/series/{seriesId}/images/query?{query.ToQueryParams()}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQueryAlternative query, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<Image[]>>($"/series/{seriesId}/images/query?{query.ToQueryParams()}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<ImagesSummary>>($"/series/{seriesId}/images", cancellationToken).ConfigureAwait(false);
        }
    }
}
