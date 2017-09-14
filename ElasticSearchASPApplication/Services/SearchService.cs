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
    public class SearchService : ISearch<Product>
    {
        private readonly IElasticClient client;

        public SearchService()
        {
            client = Config.GetClient();
        }

        /// <summary>
        /// TODO
        /// Autocomplete functionality of search box
        /// </summary>
        /// <param name="query"></param>
        public void Autocomplete(string query)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// /{index}/{type}/{id}
        /// /teknosa/smartphone/_search and the index "teknosa" and type "smartphone"
        /// </summary>
        /// <param name="query"></param>
        public IReadOnlyCollection<Product> TextSearch(string query)
        {
            var searchResponse = client.Search<Product>(s => s
              .From(0)
              .Size(10)
              .Query(q => q
                   .Match(m => m
                      .Field(f => f.Name)
                      .Query(query)
                   )
              )
             );

            var product = (IReadOnlyCollection<Product>) searchResponse.Documents;

            Console.WriteLine("TextSearch", product);
            return product;
        }
    }
}