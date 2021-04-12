namespace InfoGatherer.ApiClients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using System.Text.Json;
    using InfoGatherer.Models;

    public class RDAPApi : BaseApiClient
    {
        public RDAPApi(IOptions<ApiSettings> apiUrls, HttpClient httpClient) : base(new Uri(apiUrls.Value.RDAP), httpClient)
        {
        }

        public async Task<DomainInfo> GetDomainInfo(string domainName)
        {
            return await this.GetDomainInfo(new Uri($"domain/{domainName}", UriKind.Relative));
        }

        public async Task<IPInfo> GetIPInfo(string ipAddress)
        {
            return await this.GetIPInfo(new Uri($"ip/{ipAddress}", UriKind.Relative));
        }

        private async Task<DomainInfo> GetDomainInfo(Uri uri)
        {
            var getResponse = await this.Get(uri);

            var domainInfoString = await getResponse.Content.ReadAsStringAsync();
            var domainInfo = JsonSerializer.Deserialize<DomainInfo>(domainInfoString);
            return domainInfo;
        }

        private async Task<IPInfo> GetIPInfo(Uri uri)
        {
            var getResponse = await this.Get(uri);

            var ipInfoString = await getResponse.Content.ReadAsStringAsync();
            var ipInfo = JsonSerializer.Deserialize<IPInfo>(ipInfoString);
            return ipInfo;
        }
    }
}