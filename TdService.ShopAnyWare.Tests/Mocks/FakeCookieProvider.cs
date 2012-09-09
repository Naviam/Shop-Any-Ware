// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeCookieProvider.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the FakeCookieProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using TdService.Infrastructure.CookieStorage;

    /// <summary>
    /// The fake cookie provider.
    /// </summary>
    public class FakeCookieProvider : ICookieStorageService
    {
        /// <summary>
        /// The cookies.
        /// </summary>
        private readonly Dictionary<string, string> cookies = new Dictionary<string, string>();

        /// <summary>
        /// The collections.
        /// </summary>
        private readonly Dictionary<string, NameValueCollection> collections = new Dictionary<string, NameValueCollection>();

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
            this.cookies.Add(key, value);
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
            this.collections.Add(key, values);
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
            string value;
            return this.cookies.TryGetValue(key, out value) ? value : null;
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
            NameValueCollection value;
            return this.collections.TryGetValue(key, out value) ? value : null;
        }
    }
}