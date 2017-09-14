using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticSearchASPApplication.Services;
using Nest;

namespace ElasticSearchTest.cs
{
    [TestClass]
    public class ElasticConection
    {
        [TestMethod]
        public void CreateConnection()
        {
           IElasticClient client = ElasticConfig.GetClient();
           Assert.IsNotNull(client);
        }
    }
}
