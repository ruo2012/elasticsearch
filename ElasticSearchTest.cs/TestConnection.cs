using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticSearchASPApplication.Services;
using Nest;
using System.Configuration;
namespace ElasticSearchTest.cs
{
    [TestClass]
    public class TestConnection
    {

        [TestMethod]
        public void InitURL()
        {
            var node = new Uri("http://localhost:9200/"); //Config.URL
            Assert.AreEqual("http://localhost:9200/", node.AbsoluteUri);
        }

        [TestMethod]
        public void CreateConnection()
        {
            var node = new Uri("http://localhost:9200/"); //Config.URL
            var settings = new ConnectionSettings(node);
            settings.DefaultIndex("company"); // Config.IndexName
            IElasticClient client = new ElasticClient(settings);
            Assert.IsNotNull(client);
        }
    }
}
