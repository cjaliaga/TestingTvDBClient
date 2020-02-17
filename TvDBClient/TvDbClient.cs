using System.Net.Http;
using Microsoft.Extensions.Options;
using TvDBClient.Authentication;
using TvDBClient.Episodes;
using TvDBClient.Languages;
using TvDBClient.Search;
using TvDBClient.Series;
using TvDBClient.Updates;
using TvDBClient.Users;

namespace TvDBClient
{
    public class TvDbClient
    {
        public TvDbClient(HttpClient client, TvDBTokenAccessor tokenAccessor, IOptions<TvdbClientOptions> options)
        {
            Series = new SeriesClient(client);
            Search = new SearchClient(client);
            Episodes = new EpisodesClient(client);
            Updates = new UpdatesClient(client);
            Languages = new LanguagesClient(client);
            Users = new UsersClient(client);
            Authentication = new AuthenticationClient(client, tokenAccessor, options);
        }

        public ISeriesClient Series { get; }
        public ISearchClient Search { get; }
        public IEpisodesClient Episodes { get; }
        public IUpdatesClient Updates { get; }
        public ILanguagesClient Languages { get; }
        public IUsersClient Users { get; }
        public IAuthenticationClient Authentication { get; }
    }
}
