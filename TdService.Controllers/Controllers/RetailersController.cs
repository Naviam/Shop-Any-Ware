// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RetailersController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The retailers controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;
    using System.Xml;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Retailer;
    using TdService.UI.Web.Mapping;

    /// <summary>
    /// The retailers controller.
    /// </summary>
    public class RetailersController : BaseController
    {
        /// <summary>
        /// The retailers service.
        /// </summary>
        private readonly IRetailersService retailersService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetailersController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        /// <param name="retailersService">
        /// The retailers Service.
        /// </param>
        public RetailersController(IFormsAuthentication formsAuthentication, IRetailersService retailersService)
            : base(formsAuthentication)
        {
            this.retailersService = retailersService;
        }

        /// <summary>
        /// Get all retailers.
        /// </summary>
        /// <returns>
        /// Collection of retailers.
        /// </returns>
        public ActionResult Get()
        {
            var request = new GetRetailersRequest();
            var response = this.retailersService.GetAll(request);
            var retailers = response.ConvertToRetailerViewModelCollection();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = retailers
            };
            return jsonNetResult;
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
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = request
            };
            return jsonNetResult;
        }
    }
}