// -----------------------------------------------------------------------
// <copyright file="ICookieStorageService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.CookieStorage
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Interface for cookie storage service.
    /// </summary>
    public interface ICookieStorageService
    {
        /// <summary>
        /// Save cookie.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="expires">
        /// The expires.
        /// </param>
        void Save(string key, string value, DateTime expires);

        /// <summary>
        /// Save cookie with collection of values;
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="values">
        /// The values.
        /// </param>
        /// <param name="expires">
        /// The expires.
        /// </param>
        void SaveCollection(string key, NameValueCollection values, DateTime expires);

        /// <summary>
        /// Get cookie value by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// Cookie value.
        /// </returns>
        string Retrieve(string key);

        /// <summary>
        /// Get cookie values by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// Cookie values.
        /// </returns>
        NameValueCollection RetrieveCollection(string key);
    }
}