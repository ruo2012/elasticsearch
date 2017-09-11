using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchASPApplication.Services
{
    /// <summary>
    /// Full text search service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISearch<T>
    {
        /// <summary>
        /// The search method will execute the multi match query against user input.
        /// </summary>
        /// <param name="text">user input</param>
        void TextSearch(string query);
        
        /// <summary>
        ///TODO: Autocomplete 
        /// </summary>
        /// <param name="text"></param>
        void Autocomplete(string query);
    }
}