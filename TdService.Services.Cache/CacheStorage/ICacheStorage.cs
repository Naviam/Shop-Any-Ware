// -----------------------------------------------------------------------
// <copyright file="ICacheStorage.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Cache.CacheStorage
{
    /// <summary>
    /// Interface for cache storage.
    /// </summary>
    public interface ICacheStorage
    {
        /// <summary>
        /// Remove object from cache storage by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        void Remove(string key);

        /// <summary>
        /// Save object with unique key to cache storage.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        void Store(string key, object data);

        /// <summary>
        /// Get object from cache storage by key.
        /// </summary>
        /// <param name="storageKey">
        /// The storage key.
        /// </param>
        /// <typeparam name="T">
        /// Any class type.
        /// </typeparam>
        /// <returns>
        /// Object of custom type.
        /// </returns>
        T Retrieve<T>(string storageKey);
    }
}