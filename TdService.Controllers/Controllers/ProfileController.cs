// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the ProfileController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
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
            return this.View();
        }
    }
}