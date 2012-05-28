// -----------------------------------------------------------------------
// <copyright file="CookieStorageService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.CookieStorage
{
    using System;
    using System.Web;

    /// <summary>
    /// Cookie storage service.
    /// </summary>
    public class CookieStorageService : ICookieStorageService
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
            var cookie = HttpContext.Current.Response.Cookies[key];
            if (cookie == null)
            {
                var c = new HttpCookie(key, value) { Expires = expires };
                HttpContext.Current.Response.Cookies.Add(c);
            }
            else
            {
                cookie.Value = value;
                cookie.Expires = expires;
            }
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
            var cookie = HttpContext.Current.Request.Cookies[key];
            return cookie != null ? cookie.Value : string.Empty;
        }
    }
}