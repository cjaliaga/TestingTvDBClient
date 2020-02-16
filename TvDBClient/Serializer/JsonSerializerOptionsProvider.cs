using System.Text.Json;

namespace TvDBClient
{
    internal static class JsonSerializerOptionsProvider
    {
        private static JsonSerializerOptions _options;

        public static JsonSerializerOptions Options
        {
            get 
            {
                if(_options == null)
                {
                    _options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };

                    _options.Converters.Add(new StringToNullableIntegerConverter());
                }

                return _options;
            }
        }

    }
}
