using System;
using System.Configuration;
using Nest;

namespace ElasticSearchASPApplication.Services
{
    /// <summary>
    /// Class for instantiating a client and having it connect to the server
    /// </summary>
    public static class Config
    {
        public static string IndexName
        {
            get { return ConfigurationManager.AppSettings["indexName"]; }
        }

        public static string URL
        {
            get { return ConfigurationManager.AppSettings["elastisearchUrl"]; }
        }

        /// <summary>
        /// Creates a client to communicate with Elasticsearch
        /// </summary>
        /// <returns></returns>
        public static IElasticClient GetClient()
        {
            var node = new Uri("http://localhost:9200"); //Config.URL
            var settings = new ConnectionSettings(node);
            settings.DefaultIndex("company"); // Config.IndexName
            return new ElasticClient(settings);
        }
    }
}