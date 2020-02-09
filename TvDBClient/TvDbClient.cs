using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TvDBClient
{
    public class TvDbClient
    {
        private readonly HttpClient _client;

        public TvDbClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetShow(int id)
        {
            var request = await _client.GetAsync($"/series/{id}");
            return await request.Content.ReadAsStringAsync();
        }
    }
}
