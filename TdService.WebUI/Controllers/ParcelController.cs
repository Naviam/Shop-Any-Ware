// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParcelController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the ParcelController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// This controller contains methods to work with parcels.
    /// </summary>
    public class ParcelController : BaseController
    {
        /// <summary>
        /// Get the list of parcels.
        /// </summary>
        /// <returns>
        /// Returns view with the list of parcels.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
