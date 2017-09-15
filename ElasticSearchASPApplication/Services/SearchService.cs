using ElasticSearchASPApplication.Models;
using System.Linq;
using Nest;
using System;
using System.Collections.Generic;

namespace ElasticSearchASPApplication.Services
{
    /// <summary>
    /// Class for full text search functionality
    /// </summary>
    /// <remarks>This will inherit just the last &lt;para&gt; tag from
    /// the base class's &lt;remarks&gt; tag:
    /// <inheritdoc select="para[last()]" />
    /// </remarks>
    public class SearchService : ISearchService<Product>
    {
        private readonly IElasticClient client;

        public SearchService()
        {
            client = Config.GetClient();
        }

        public IReadOnlyCollection<Product> SimpleSearch(string query)
        {
            var searchResponse = client.Search<Product>(s => s
                .Query(q => q
                    .QueryString(m => m
                        .Query(query)
                   )
                )
            );
            return searchResponse.Documents;
        }

        public IReadOnlyCollection<Product> Filter(string query)
        {
            var searchResponse = client.Search<Product>(s => s.
                Query(q => q
                    .Bool(b => b
                        .Must(mu => mu
                            .Match(m => m
                                .Field(f => f.Name)
                                .Query(query)
                            )
                        )
                        .Filter(f => f
                            .Range( r => r
                                .GreaterThan(1000)
                                .LessThan(4000)
                            )
                        )
                    )
                )
            );

            return searchResponse.Documents;
        }

        public IReadOnlyCollection<Product> FilterWithSpecificNumber(string query)
        {
            var searchResponse = client.Search<Product>(s => s.
                Query(q => q
                    .Bool(b => b
                        .Must(mu => mu
                            .Match(m => m
                                .Field(f => f.Name)
                                .Query(query)
                            )
                        )
                        .Filter(f => f
                            .Term(t => t.
                                Price, 2900
                            )
                        )
                    )
                )
            );

            return searchResponse.Documents;
        }

        public IReadOnlyCollection<Product> Sort(string query)
        {
            var searchResponse = client.Search<Product>(s => s.
                Query(q => q
                    .Bool(b => b
                        .Must(mu => mu
                            .MatchAll()
                        )
                     )
                )
                .Sort(a => a
                    .Ascending(p => p.Price)
                 )
            );
            return searchResponse.Documents;
        }
     
        public IReadOnlyCollection<Product> Pagination(string query) {
            var searchResponse = client.Search<Product>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(mu => mu
                            .MatchAll()
                     )
                  )
             )
             .Size(20)
         );
            return searchResponse.Documents;
        }
    }
}