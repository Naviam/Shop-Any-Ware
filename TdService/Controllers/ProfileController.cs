// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the ProfileController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Profile controller contains methods to work with user's profile.
    /// </summary>
    public class ProfileController : BaseController
    {
        /// <summary>
        /// Get Profile Summary
        /// </summary>
        /// <returns>
        /// Returns view with the profile details.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Change user's password.
        /// </summary>
        /// <returns>
        /// Returns view with the profile details.
        /// </returns>
        [HttpPost]
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// Update user's name and surname.
        /// </summary>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        public ActionResult Update()
        {
            return View();
        }
    }
}