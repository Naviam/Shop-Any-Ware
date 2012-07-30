// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RetailersController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The retailers controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// The retailers controller.
    /// </summary>
    public class RetailersController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetailersController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public RetailersController(IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
        }

        /// <summary>
        /// Autosuggest retailer name and url.
        /// </summary>
        /// <param name="searchText">
        /// The search string.
        /// </param>
        /// <returns>
        /// Json result.
        /// </returns>
        public ActionResult Suggest(string searchText)
        {
            var request = new object();
            return this.Json(request);
        }
    }
}