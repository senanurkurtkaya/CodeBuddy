using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddy.Infrastructure.Elastic
{
    public static class Register
    {
        public static IServiceCollection AddElasticClient(this IServiceCollection services, string url, string apiKey)
        {
            var settings = new ElasticsearchClientSettings(new Uri(url))
                .Authentication(new ApiKey(apiKey));

            services.AddSingleton(settings);

            return services;
        }
    }
}
