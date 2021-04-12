namespace InfoGatherer
{
    using Microsoft.Extensions.DependencyInjection;
    using InfoGatherer.ApiClients;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClients(this IServiceCollection services)
        {
            services
                .AddHttpClient<GeoIPApi>(client =>
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                });
            services
                .AddHttpClient<RDAPApi>(client =>
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                });
            services
                .AddHttpClient<ReverseDNSApi>(client =>
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                });

            return services;
        }
    }
}