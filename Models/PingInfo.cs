namespace InfoGatherer.Models
{
    using System.Net.NetworkInformation;

    public class PingInfo
    {
        public PingInfo(PingReply pingResponse)
        {
            this.Address = pingResponse.Address.ToString();
            this.Status = pingResponse.Status.ToString();
            this.RoundTripTime = pingResponse.RoundtripTime;
        }

        public string Address { get; set; }

        public string Status { get; set; }

        public long RoundTripTime { get; set; }
    }
}