// -----------------------------------------------------------------------
// <copyright file="ICookieStorageService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.CookieStorage
{
    using System;

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
        /// Get cookie value by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// Cookie value.
        /// </returns>
        string Retrieve(string key);
    }
}