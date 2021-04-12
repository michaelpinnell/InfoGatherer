namespace InfoGatherer.ApiClients
{
    using System;
    using System.Net.Http;
    using Microsoft.Extensions.Options;
    using InfoGatherer.Models;

    public class GeoIPApi : BaseApiClient
    {
        private readonly string accessKey;

        public GeoIPApi(IOptions<ApiSettings> apiSettings, HttpClient httpClient) : base(new Uri(apiSettings.Value.GeoIP), httpClient)
        {
            this.accessKey = apiSettings.Value.GeoIPAccessKey;
        }
    }
}