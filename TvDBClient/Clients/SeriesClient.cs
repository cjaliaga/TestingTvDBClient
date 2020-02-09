using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TvDBClient.Models;

namespace TvDBClient
{
    internal class SeriesClient : ISeriesClient
    {
        private readonly HttpClient _client;

        public SeriesClient(HttpClient client)
        {
            _client = client;
        }

        public Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<Series>>($"/series/{seriesId}").ConfigureAwait(false);
        }

        public Task<TvDbResponse<EpisodeRecord[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TvDbResponse<EpisodeRecord[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, string>> GetHeadersAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQueryAlternative query, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
