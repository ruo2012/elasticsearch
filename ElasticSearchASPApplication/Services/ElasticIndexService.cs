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

        private readonly IElasticClient client;

        public ElasticIndexService()
        {
            client = ElasticSearchASPApplication.Services.ElasticConfig.GetClient();
        }

        /// <summary>
        /// Creates index
        /// 
        /// </summary>
        public void CreateIndex()
        {
            var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };

            var indexConfig = new IndexState
            {
                Settings = settings
            };

            if (!client.IndexExists("product").Exists)
            {
                client.CreateIndex("product", c => c
                    .InitializeUsing(indexConfig)
                        .Mappings(m => m
                            .Map<Product>(mp => mp
                                .AutoMap())));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">C:\Users\xxx\source\repos\ElasticSearchRepo\elasticsearch-nest-webapi-angularjs\elasticsearch-nest-webapi-angularjs\data </param>
        /// <param name="maxItems">maxItems</param>
        private void BulkIndex(string path, int maxItems)
        {
           
        }
    }
}