using System.Net.Http;

namespace TvDBClient
{
    public class TvDbClient
    {
        public TvDbClient(HttpClient client)
        {
            Series = new SeriesClient(client);
        }

        public ISeriesClient Series { get;}
    }
}
