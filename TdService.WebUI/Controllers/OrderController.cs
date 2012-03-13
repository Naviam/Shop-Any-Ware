// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the OrderController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Order controller class contains methods to work with user orders.
    /// </summary>
    public class OrderController : BaseController
    {
        /// <summary>
        /// The default view for orders.
        /// </summary>
        /// <returns>
        /// Returns the list of user's orders.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}