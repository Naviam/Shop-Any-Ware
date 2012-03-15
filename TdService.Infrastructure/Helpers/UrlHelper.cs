// -----------------------------------------------------------------------
// <copyright file="UrlHelper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Helpers
{
    using System.Web;

    /// <summary>
    /// This class role is to produce a fully resolved URL for a resource.
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// Resolve url.
        /// </summary>
        /// <param name="resource">
        /// The resource.
        /// </param>
        /// <returns>
        /// Resolved url.
        /// </returns>
        public static string Resolve(string resource)
        {
            var scheme = HttpContext.Current.Request.Url.Scheme;
            var host = HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
            var applicationPath = HttpContext.Current.Request.ApplicationPath ?? string.Empty;
            if (string.IsNullOrEmpty(applicationPath))
            {
                applicationPath = applicationPath.Equals("/") ? string.Empty : HttpContext.Current.Request.ApplicationPath;                
            }

            return string.Format("{0}://{1}{2}{3}", scheme, host, applicationPath, resource);
        }
    }
}