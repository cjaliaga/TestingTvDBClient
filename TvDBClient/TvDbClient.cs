using System.Net.Http;
using TvDBClient.Clients;
using TvDBClient.Series;

namespace TvDBClient
{
    public class TvDbClient
    {
        public TvDbClient(HttpClient client)
        {
            Series = new SeriesClient(client);
        }

        public ISeriesClient Series { get;}

        public ISearchClient Search { get; }
    }
}
