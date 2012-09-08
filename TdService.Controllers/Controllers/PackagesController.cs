// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackagesController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The packages controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;
    using System.Xml;

    using TdService.Infrastructure.Authentication;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Package;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Package;

    /// <summary>
    /// The packages controller.
    /// </summary>
    public class PackagesController : BaseController
    {
        /// <summary>
        /// The packages service.
        /// </summary>
        private readonly IPackagesService packagesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackagesController"/> class.
        /// </summary>
        /// <param name="packagesService">
        /// The packages service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public PackagesController(
            IPackagesService packagesService,
            IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.packagesService = packagesService;
        }

        /// <summary>
        /// Add new package.
        /// </summary>
        /// <param name="packageName">
        /// The package name.
        /// </param>
        /// <returns>
        /// Json result with package view model.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Add(string packageName)
        {
            var request = new AddPackageRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken(), Name = packageName };

            var response = this.packagesService.AddPackage(request);
            var result = response.ConvertToPackageViewModel();
            result.Message = DashboardViewResources.PackageCreatedSuccessMessage;
            result.MessageType = MessageType.Success.ToString();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Get recent packages.
        /// </summary>
        /// <returns>
        /// Json result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Recent()
        {
            var request = new GetRecentPackagesRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.packagesService.GetRecent(request);
            var result = response.ConvertToPackageViewModelCollection();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Remove package in new status.
        /// </summary>
        /// <param name="packageId">
        /// The package ID to remove.
        /// </param>
        /// <returns>
        /// Json result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Remove(int packageId)
        {
            var request = new RemovePackageRequest
            {
                IdentityToken = this.FormsAuthentication.GetAuthenticationToken(),
                Id = packageId
            };
            var response = this.packagesService.RemovePackage(request);
            var result = new PackageViewModel
            {
                Id = packageId,
                Message = response.Message ?? DashboardViewResources.PackageRemovedSuccess,
                MessageType = response.MessageType.ToString()
            };

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }
    }
}