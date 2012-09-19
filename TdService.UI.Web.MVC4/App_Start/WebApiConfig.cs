// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The web api config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.MVC4.App_Start
{
    using System.Web.Http;

    /// <summary>
    /// The web api config.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
    }
}
