namespace InfoGatherer.ApiClients
{
    using System;
    using System.Net.Http;
    using Microsoft.Extensions.Options;
    using InfoGatherer.Models;

    public class ReverseDNSApi : BaseApiClient
    {
        private readonly string apiKey;
        public ReverseDNSApi(IOptions<ApiSettings> apiSettings, HttpClient httpClient) : base(new Uri(apiSettings.Value.ReverseDNS), httpClient)
        {
            this.apiKey = apiSettings.Value.ReverseDNSApiKey;
        }
    }
}