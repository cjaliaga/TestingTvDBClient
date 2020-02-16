using System.Net.Http;
using TvDBClient.Episodes;
using TvDBClient.Search;
using TvDBClient.Series;

namespace TvDBClient
{
    public class TvDbClient
    {
        public TvDbClient(HttpClient client)
        {
            Series = new SeriesClient(client);
            Search = new SearchClient(client);
            Episodes = new EpisodesClient(client);
        }

        public ISeriesClient Series { get;}

        public ISearchClient Search { get; }

        public IEpisodesClient Episodes { get; set; }
    }
}
