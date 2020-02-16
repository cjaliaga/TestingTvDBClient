namespace TvDBClient
{
    public class TvdbClientOptions
    {
        public string ApiKey { get; set; }
        public string BaseAddress { get; set; } = "https://api.thetvdb.com";
        public string AcceptedLanguage { get; set; } = "en";
    }
}
