using Elasticsearch.Net;
using Elasticsearch.Net.Aws;
using Microsoft.Extensions.Configuration;
using System;
using Nest;
using Microsoft.Extensions.DependencyInjection;
using SmartApartmentElasticSearch.Services;
using SmartApartmentElasticSearch.Services.Interfaces;

namespace SmartApartmentElasticsearch.Core.ConfigExtensions
{
    public static class SmartApartmentServicesRegistrations
    {
        public static void AddElasticsearchCon(this IServiceCollection services, IConfiguration config)
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var httpConnection = new AwsHttpConnection(config.GetAWSOptions("AWS"));
            var settings = new ConnectionSettings(pool, httpConnection);

            var client = new ElasticClient(settings);

            services.AddSingleton(client);
            services.AddScoped<ISearchRepo, SearchRepo>();
        }
    }
     
    
}
