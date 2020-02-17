using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TvDBClient.Models;

namespace TvDBClient.Users
{
    internal class UsersClient : IUsersClient
    {
        private readonly HttpClient _client;

        internal UsersClient(HttpClient client)
        {
            _client = client;
        }

        public Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Episode, episodeId, rating, cancellationToken);
        }

        public Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Image, imageId, rating, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddRatingAsync(
            RatingType itemType,
            int itemId,
            decimal rating,
            CancellationToken cancellationToken = default)
        {
            return await _client
                .PutJsonAsync<TvDbResponse<UserRatings[]>>($"/user/ratings/{itemType.ToPascalCase()}/{itemId}/{rating}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, decimal rating, CancellationToken cancellationToken = default)
        {
            return AddRatingAsync(RatingType.Series, seriesId, rating, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client
                .PutJsonAsync<TvDbResponse<UserFavorites>>($"/user/favorites/{seriesId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _client.GetJsonAsync<TvDbResponse<User>>("/user", cancellationToken).ConfigureAwait(false);
        }

        public Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Episode, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TvDbResponse<UserFavorites>>("/user/favorites", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Image, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TvDbResponse<UserRatings[]>>("/user/ratings", cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken = default)
        {
            return await _client
                .GetJsonAsync<TvDbResponse<UserRatings[]>>($"/user/ratings/query?itemType={type.ToPascalCase()}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync(CancellationToken cancellationToken = default)
        {
            return GetRatingsAsync(RatingType.Series, cancellationToken);
        }

        public Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Episode, episodeId, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return await _client
                .DeleteJsonAsync<TvDbResponse<UserFavorites>>($"/user/favorites/{seriesId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Image, imageId, cancellationToken);
        }

        public async Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken = default)
        {
            await _client
                .DeleteAsync($"/user/ratings/{itemType.ToPascalCase()}/{itemId}", cancellationToken)
                .ConfigureAwait(false);
        }

        public Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken = default)
        {
            return RemoveRatingAsync(RatingType.Series, seriesId, cancellationToken);
        }
    }
}
