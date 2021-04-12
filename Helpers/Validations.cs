namespace InfoGatherer.Helpers
{
    using System;
    using System.Text.RegularExpressions;

    public static class Validations
    {
        private static readonly Regex IPV4Regex = new Regex("(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])");

        private static readonly Regex IPV6Regex = new Regex("((([0-9a-fA-F]){1,4})\\:){7}([0-9a-fA-F]){1,4}");
        public static bool IsValidDomainName(string domainName)
        {
            return Uri.CheckHostName(domainName) != UriHostNameType.Unknown;
        }

        public static bool IsValidIpAddress(string ipAddrress)
        {
            return IPV4Regex.IsMatch(ipAddrress) || IPV6Regex.IsMatch(ipAddrress);
        }
    }
}