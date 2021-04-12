namespace InfoGatherer.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using InfoGatherer.ApiClients;
    using InfoGatherer.Helpers;
    using InfoGatherer.Models;

    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class InfoGatheringController : ControllerBase
    {
        private static readonly List<string> DefaultServices = new List<string>
        {
            "GeoIP", "RDAP", "Reverse DNS", "Ping"
        };

        private readonly ILogger<InfoGatheringController> _logger;

        private readonly RDAPApi rdapApi;

        private readonly GeoIPApi geoIpApi;

        private readonly ReverseDNSApi reverseDnsApi;

        private readonly PingApi pingApi;

        public InfoGatheringController(
            ILogger<InfoGatheringController> logger,
            IConfiguration configSettings,
            GeoIPApi geoIpApi,
            PingApi pingApi,
            RDAPApi rdapApi,
            ReverseDNSApi reverseDNSApi)
        {
            _logger = logger;
            this.geoIpApi = geoIpApi;
            this.pingApi = pingApi;
            this.rdapApi = rdapApi;
            this.reverseDnsApi = reverseDNSApi;
        }

        [HttpGet("{ipOrDomain}")]
        public async Task<ActionResult<GatheredInfo>> GetAsync(string ipOrDomain,[FromQuery] List<string> servicesToQuery = null)
        {
            if (!Validations.IsValidDomainName(ipOrDomain) && !Validations.IsValidIpAddress(ipOrDomain))
            {
                return this.BadRequest("Provided string is neither a valid IP or domain");
            }
            if (servicesToQuery == null || !servicesToQuery.Any())
            {
                servicesToQuery = DefaultServices;
            }
            var gatheredInfo = new GatheredInfo();
            gatheredInfo.DomainInfo = await this.rdapApi.GetDomainInfo(ipOrDomain);

            gatheredInfo.PingInfo = await this.pingApi.Get(ipOrDomain);

            gatheredInfo.IpInfo = await this.rdapApi.GetIPInfo(gatheredInfo.PingInfo.Address);
            // var responseList = servicesToQuery.Select(async service =>
            // {
            //     var gatheredInfo = new GatheredInfo();
            //     if (Validations.IsValidDomainName(ipOrDomain))
            //     {
            //         gatheredInfo.IpInfo =  await ((RDAPApi)this.ServiceLookup[service]).GetIPInfo(ipOrDomain);
            //     }
            //     else
            //     {
            //         gatheredInfo.DomainInfo = await ((RDAPApi)this.ServiceLookup[service]).GetDomainInfo(ipOrDomain);
            //     }

            //     return gatheredInfo;
            // });

            return gatheredInfo;
        }
    }
}
