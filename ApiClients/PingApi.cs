namespace InfoGatherer.ApiClients
{
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;
    using InfoGatherer.Models;

    public class PingApi
    {
        private readonly Ping ping;

        public PingApi()
        {
            this.ping = new Ping();
        }

        public async Task<PingInfo> Get(string ipOrDomain)
        {
            var pingResponse = await this.ping.SendPingAsync(ipOrDomain);
            return new PingInfo(pingResponse);
        }
    }
}