using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;
using ElasticSearchASPApplication.Models;

namespace ElasticSearchASPApplication.Services
{
    public class ElasticIndexService
    {
        public static Uri EsNode;
        public static ConnectionSettings EsConfig;
        public static ElasticClient EsClient;
        public List<IndexResponse> indexResponseList;

        private readonly IElasticClient client;

        public ElasticIndexService()
        {
            indexResponseList = new List<IndexResponse>();
            client = ElasticSearchASPApplication.Services.ElasticConfig.GetClient();
        }

        /// <summary>
        /// Creates index
        /// 
        /// </summary>
        public void CreateIndex()
        {
            //create dummy data
            List<Product> productList = new List<Product>
            {
                new Product{ Name = "iPhone6s", Price = 3000, Currency = "TL" },
                new Product{ Name = "iPhone6", Price = 2500, Currency = "TL" },
                new Product{ Name = "iPhone7", Price = 4500, Currency = "TL" },
                new Product{ Name = "Samsung Galaxy S8", Price = 3400, Currency = "TL" },
                new Product{ Name = "Samsung Galaxy S7", Price = 2900, Currency = "TL" }
            };

            //create index for each product
            if (!client.IndexExists(ElasticConfig.IndexName).Exists)
            {
                foreach (var product in productList)
                {
                   client.Index(product);
                }
            }
          
        }
    }
}