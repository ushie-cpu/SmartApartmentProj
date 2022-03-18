using Microsoft.AspNetCore.Mvc;
using Nest;
using NPoco.Expressions;
using NSubstitute.Core;
using SmartApartmentElasticSearch.Models;
using SmartApartmentElasticSearch.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SmartApartmentElasticSearch.Services
{
    public class SearchRepo : ISearchRepo
    {
        private readonly ElasticClient _client;

        public SearchRepo(ElasticClient client)
        {
            _client = client;
        }

        public Task<ISearchResponse<Property>> MatchAll()
        {
            var results = _client.Search<Property>(s => s.Query(q => q
           .MatchAll()));

            return Task.Run(() => results);
        }


        public Task<ISearchResponse<Mgmt>> QuerySearch(string query)
        {
            ISearchResponse<Mgmt> results;

            if (!string.IsNullOrWhiteSpace(query))
            {
                results = _client.Search<Mgmt>(s => s.Query(q => q.Term(t => t
                           .Field(f => f.Market)
                           .Value(query)
                       )
                   )
                );
            }
            else
            {
                results = _client.Search<Mgmt>(s => s
                    .Query(q => q
                        .MatchAll()
                    )
                );
            }

            return Task.Run(() => results);
        }
    }
}


