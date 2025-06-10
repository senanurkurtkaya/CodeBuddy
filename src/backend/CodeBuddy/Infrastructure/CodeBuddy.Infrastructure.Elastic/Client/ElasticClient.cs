using Elastic.Clients.Elasticsearch;

namespace CodeBuddy.Infrastructure.Elastic.Client
{
    public interface IElasticClient
    {
        Task CreateIndexIfNotExists(string indexName, CancellationToken cancellationToken);
    }

    internal class ElasticClient : IElasticClient
    {
        private readonly ElasticsearchClient _client;

        public ElasticClient(ElasticsearchClientSettings settings)
        {
            _client = new ElasticsearchClient(settings);
        }

        public async Task CreateIndexIfNotExists(string indexName, CancellationToken cancellationToken)
        {
            var doesExistsResponse = await _client.Indices.ExistsAsync(indexName, cancellationToken);

            if (!doesExistsResponse.IsSuccess())
            {
                throw new Exception("Index validation failed.");
            }

            if (doesExistsResponse.Exists)
            {
                return;
            }

            await _client.Indices.CreateAsync(indexName, cancellationToken);
        }
    }
}
