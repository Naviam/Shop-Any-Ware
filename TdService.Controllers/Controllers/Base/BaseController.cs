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
    using System.Web;
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
            var cultureCookie = requestContext.HttpContext.Request.Cookies["culture"];
            if (cultureCookie == null)
            {
                // get domain name
                var url = this.Request.Url;
                if (url != null && url.AbsoluteUri.IndexOf("shopanyware.ru", System.StringComparison.Ordinal) >= 0)
                {
                    cultureCookie = new HttpCookie("culture", "ru");
                    Response.Cookies.Set(cultureCookie);
                }
            }

            if (cultureCookie != null)
            {
                var culture = new CultureInfo(cultureCookie.Value);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            base.Initialize(requestContext);
        }
    }
}