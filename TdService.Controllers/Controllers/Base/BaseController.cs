// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The base controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers.Base
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    /// <summary>
    /// The base controller.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Cookies["culture"] != null)
            {
                var culture = new CultureInfo(requestContext.HttpContext.Request.Cookies["culture"].Value);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            base.Initialize(requestContext);
        }
    }
}