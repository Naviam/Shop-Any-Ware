// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Home controller contains methods to display pages for unregistered shoppers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;

    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// Home controller contains methods to display pages for unregistered shoppers.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// The default page.
        /// </summary>
        /// <returns>
        /// Returns view with the short information about service.
        /// </returns>
        public ActionResult Index()
        {
            var model = new MainViewModel
                { SignInViewModel = new SignInViewModel(), SignUpViewModel = new SignUpViewModel() };
            return this.View(model);
        }

        /// <summary>
        /// The page contains information about online US retailers.
        /// </summary>
        /// <returns>
        /// Returns view with the catalog of onliner US retailers.
        /// </returns>
        public ActionResult Shops()
        {
            return this.View();
        }

        /// <summary>
        /// The page with price information for the service.
        /// </summary>
        /// <returns>
        /// Returns view with the table of service plans.
        /// </returns>
        public ActionResult Services()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains information about terms and conditions of using this service.
        /// </summary>
        /// <returns>
        /// Returns view with the information about terms and conditions.
        /// </returns>
        public ActionResult Terms()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains help information for new users to get started quickly.
        /// </summary>
        /// <returns>
        /// Returns view with help information and video material.
        /// </returns>
        public ActionResult Help()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains contact information.
        /// </summary>
        /// <returns>
        /// Returns view with the contact information.
        /// </returns>
        public ActionResult Contact()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains about us information.
        /// </summary>
        /// <returns>
        /// Returns view with the about us information.
        /// </returns>
        public ActionResult About()
        {
            return this.View();
        }
    }
}