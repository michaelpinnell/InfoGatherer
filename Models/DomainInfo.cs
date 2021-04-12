namespace InfoGatherer.Models
{
    using System.Collections.Generic;

    public class DomainInfo
    {
        public List<string> status { get; set; }

        public string ldhName { get; set; }

        public string handle { get; set; }

        public List<NameServers> nameServers { get; set; }

        public List<Event> events { get; set; }
    }
}