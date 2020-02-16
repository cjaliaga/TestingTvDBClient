using System.Net.Http;
using TvDBClient.Episodes;
using TvDBClient.Languages;
using TvDBClient.Search;
using TvDBClient.Series;
using TvDBClient.Updates;

namespace TvDBClient
{
    public class TvDbClient
    {
        public TvDbClient(HttpClient client)
        {
            Series = new SeriesClient(client);
            Search = new SearchClient(client);
            Episodes = new EpisodesClient(client);
            Updates = new UpdatesClient(client);
            Languages = new LanguagesClient(client);
        }

        public ISeriesClient Series { get;}
        public ISearchClient Search { get; }
        public IEpisodesClient Episodes { get;}
        public IUpdatesClient Updates { get; }
        public ILanguagesClient Languages { get; }
    }
}
