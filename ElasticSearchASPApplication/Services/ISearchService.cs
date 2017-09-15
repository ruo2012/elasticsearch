using System.Collections.Generic;

namespace ElasticSearchASPApplication.Services
{
    /// <summary>
    /// Full text search service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISearchService<T>
    {
        /// <summary>
        /// The search method will execute the multi match query against user input.
        /// </summary>
        /// <param name="text">user input</param>
        /// <see cref="https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl-query-string-query.html"/>

        /// Query DSL:
        // GET /company/product/_search/
        // {
        //   "query": {
        //      "query_string": {
        //         "query": "Sony"
        //      }
        //   }
        // }
        IReadOnlyCollection<T> SimpleSearch(string query);

        /// <summary>
        /// Given a <code>query</code>, retrieves products whose price is between 1000 and 4000.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <see cref="https://www.elastic.co/guide/en/elasticsearch/client/net-api/5.x/writing-queries.html#structured-search"/>
        /// <see cref="https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl-range-query.html"/>
        /// 
        /// Query DSL:
        /// POST /company/product/_search/
        //{
        //   "query": {
        //      "bool": {
        //         "must": {
        //            "match": {
        //               "name": "Samsung"
        //            }
        //         },
        //         "filter": [
        //            {
        //               "range": {
        //                  "price": {
        //                     "gte": 1000,
        //                     "lte": 4000
        //                  }
        //                }
        //            }
        //         ]
        //      }
        //   }
        //}
        IReadOnlyCollection<T> Filter(string query);

        /// <summary>
        /// Given a <code>query</code>, retrieves products whose price is 2900.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <see cref="https://www.elastic.co/guide/en/elasticsearch/client/net-api/5.x/writing-queries.html#structured-search"/>
        /// <see cref="https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl-range-query.html"/>

        /// <summary>
        /// Query DSL:
        /// POST /company/product/_search/
        //  {
        //   "query": {
        //      "bool": {
        //         "must": {
        //            "match": {
        //               "name": "Samsung"
        //            }
        //         },
        //         "filter": {
        //            "term": {
        //               "price": 2900
        //            }
        //         }
        //      }
        //   }
        //  }
        IReadOnlyCollection<T> FilterWithSpecificNumber(string query);

        /// <summary>
        /// Given a <code>query</code>, retrieves products whose price is equal to 2900.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>user input</returns>
        /// <see cref="https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/sort-usage.html"/>
        /// 

        ///Query DSL:
        // POST /company/product/_search/
        // {
        //   "query": {
        //     "match_all": {}
        //   },
        //   "sort": {
        //      "price": "asc"
        //   }
        // } 
        IReadOnlyCollection<T> Sort(string query);

        /// <summary>
        /// ElasticSearch returns the first ten hits by default. You can change it via size parameter.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IReadOnlyCollection<T> Pagination(string query);
    }
}