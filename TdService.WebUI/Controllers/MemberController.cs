// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the MemberController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The controller that contains membership methods.
    /// </summary>
    public class MemberController : BaseController
    {
        /// <summary>
        /// The default view of an authenticated user.
        /// </summary>
        /// <returns>
        /// Returns the page with all information.
        /// </returns>
        public ActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// Testing the new interface.
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}