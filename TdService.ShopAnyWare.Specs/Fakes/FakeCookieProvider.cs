// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeCookieProvider.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The fake cookie provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Fakes
{
    using System;
    using System.Collections.Specialized;

    using TdService.Infrastructure.CookieStorage;

    /// <summary>
    /// The fake cookie provider.
    /// </summary>
    public class FakeCookieProvider : ICookieStorageService
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
        public void Save(string key, string value, DateTime expires)
        {
        }

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
        public void SaveCollection(string key, NameValueCollection values, DateTime expires)
        {
        }

        /// <summary>
        /// Get cookie value by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// Cookie value.
        /// </returns>
        public string Retrieve(string key)
        {
            return null;
        }

        /// <summary>
        /// Get cookie values by key.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// Cookie values.
        /// </returns>
        public NameValueCollection RetrieveCollection(string key)
        {
            return null;
        }
    }
}