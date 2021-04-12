namespace InfoGatherer.Models
{
    using System.Collections.Generic;
    public class IPInfo
    {
        public string handle { get; set; }

        public string Name { get; set; }

        public string type { get; set; }

        public List<Event> events { get; set; }

        public List<string> status { get; set; }

        public string ipVersion { get; set; }

        public string objectClassName { get; set; }
    }
}
