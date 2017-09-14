using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;
using ElasticSearchASPApplication.Models;
using ElasticSearchASPApplication.Services;
using System.Collections.Generic;

namespace ElasticSearchTest.cs
{
    [TestClass]
    public class TextSearch
    {
        IElasticClient client = Config.GetClient();

        [TestMethod]
        public void CreateIndex()
        {
            //data
            var product = new Product()
            {
                Name = "Huawei",
                Price = 2000,
                Currency = "TL"
            };
     
            //action
            IndexResponse response = new IndexResponse();
            response = (IndexResponse) client.Index(product);

            //test
            var expected = true;
            var actual = response.IsValid;
            Assert.AreEqual(expected, actual, "Index is not valid");
            Assert.AreEqual(expected, response.Created, "Index was not created");

        }

        [TestMethod]
        public void FullTextSearch()
        {
            SearchService service = new SearchService();
            Assert.AreEqual(0, service.TextSearch("iPhone").Count);
            Assert.AreEqual(2,service.TextSearch("Huawei").Count);
        }
    }
}
