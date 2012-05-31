// -----------------------------------------------------------------------
// <copyright file="HttpContextCacheAdapter.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Cache.CacheStorage
{
    using System.Web;

    /// <summary>
    /// This is a wrapper on the default asp.net cache in memory provider.
    /// </summary>
    public class HttpContextCacheAdapter
    {
        /// <summary>
        /// Remove object from cache storage by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// Save object to cache storage with unique key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public void Store(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data);
        }

        /// <summary>
        /// Get object from cache storage by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <typeparam name="T">
        /// Custom class type of an object.
        /// </typeparam>
        /// <returns>
        /// Object of a custom class type.
        /// </returns>
        public T Retrieve<T>(string key) where T : class
        {
            return (T)HttpContext.Current.Cache.Get(key);
        }
    }
}