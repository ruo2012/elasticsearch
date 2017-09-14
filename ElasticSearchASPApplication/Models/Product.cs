using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearchASPApplication.Models
{
    public class Product
    {
        public string Name { set; get; }

        public int Price { set; get; }

        public string Currency { set; get; }
    }
}