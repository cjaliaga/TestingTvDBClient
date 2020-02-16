using System.Net.Http;
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
        }

        public ISeriesClient Series { get;}

        public ISearchClient Search { get; }
    }
}
