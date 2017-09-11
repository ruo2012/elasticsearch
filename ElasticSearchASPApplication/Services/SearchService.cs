using ElasticSearchASPApplication.Models;
using System.Linq;
using Nest;

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
            client = ElasticConfig.GetClient();
        }

        public void Autocomplete(string query)
        {
            throw new System.NotImplementedException();
        }

        public void TextSearch(string query)
        {
            var result = client.Search<Product>(x => x .Query(q => q
                                                            .MultiMatch(mp => mp
                                                                .Query(query)
                                                                    .Fields(f => f
                                                                        .Fields(f1 => f1.Name, f2 => f2.Price, f3 => f3.Currency))))
            );
        }
    }
}