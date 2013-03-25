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
    using TdService.Infrastructure.SessionStorage;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Package;
    using TdService.UI.Web.Controllers.Base;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Package;

    /// <summary>
    /// The packages controller.
    /// </summary>
    public class PackagesController : BaseAuthController
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
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
        [HttpPost]
        public ActionResult Add(string packageName, string userEmail)
        {
            EnsureUserEmailIsNotChanged(userEmail);

            var request = new AddPackageRequest { IdentityToken = userEmail, Name = packageName };

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
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
        [HttpPost]
        public ActionResult Recent(string userEmail)
        {
            EnsureUserEmailIsNotChanged(userEmail);

            var request = new GetRecentPackagesRequest { IdentityToken = userEmail };
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
        /// The history.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
        [HttpPost]
        public ActionResult History(string userEmail)
        {
            EnsureUserEmailIsNotChanged(userEmail);

            var request = new GetRecentPackagesRequest { IdentityToken = userEmail };
            var response = this.packagesService.GetHistory(request);
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
        /// JSON result.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
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