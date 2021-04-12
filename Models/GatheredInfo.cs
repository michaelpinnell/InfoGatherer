namespace InfoGatherer.Models
{
    using System.Net.NetworkInformation;

    public class GatheredInfo
    {
        public IPInfo IpInfo { get; set; }

        public DomainInfo DomainInfo { get; set; }

        public PingInfo PingInfo { get; set; }
    }
}