// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Home controller contains methods to display pages for unregistered shoppers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Home controller contains methods to display pages for unregistered shoppers.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The default page.
        /// </summary>
        /// <returns>
        /// Returns view with the short information about service.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The page contains information about online US retailers.
        /// </summary>
        /// <returns>
        /// Returns view with the catalog of onliner US retailers.
        /// </returns>
        public ActionResult Shops()
        {
            return View();
        }

        /// <summary>
        /// The page with price information for the service.
        /// </summary>
        /// <returns>
        /// Returns view with the table of service plans.
        /// </returns>
        public ActionResult Services()
        {
            return View();
        }

        /// <summary>
        /// The page contains information about terms and conditions of using this service.
        /// </summary>
        /// <returns>
        /// Returns view with the information about terms and conditions.
        /// </returns>
        public ActionResult Terms()
        {
            return View();
        }

        /// <summary>
        /// The page contains help information for new users to get started quickly.
        /// </summary>
        /// <returns>
        /// Returns view with help information and video material.
        /// </returns>
        public ActionResult Help()
        {
            return View();
        }

        /// <summary>
        /// The page contains contact information.
        /// </summary>
        /// <returns>
        /// Returns view with the contact information.
        /// </returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// The page contains about us information.
        /// </summary>
        /// <returns>
        /// Returns view with the about us information.
        /// </returns>
        public ActionResult About()
        {
            return View();
        }
    }
}