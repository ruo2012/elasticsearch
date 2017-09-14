using System.Collections.Generic;

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
        IReadOnlyCollection<T> TextSearch(string query);
        
        /// <summary>
        ///TODO: Autocomplete 
        /// </summary>
        /// <param name="text"></param>
        void Autocomplete(string query);
    }
}