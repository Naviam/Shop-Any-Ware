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
    using TdService.Infrastructure.Usps;
    using TdService.Resources;
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
        /// <param name="userEmail">
        /// The user Email.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
        [HttpPost]
        public ActionResult Add(string packageName, string userEmail)
        {
            this.EnsureUserEmailIsNotChanged(userEmail);

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
        /// <param name="userEmail">
        /// The user Email.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
        [HttpPost]
        public ActionResult Recent(string userEmail)
        {
            this.EnsureUserEmailIsNotChanged(userEmail);

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
        /// <param name="userEmail">
        /// The user Email.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
        [HttpPost]
        public ActionResult History(string userEmail)
        {
            this.EnsureUserEmailIsNotChanged(userEmail);

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

        /// <summary>
        /// The change package delivery address.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="deliveryAddressId">
        /// The delivery address id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult ChangePackageDeliveryAddress(int packageId, int deliveryAddressId)
        {
            var request = new ChangePackageDeliveryAddressRequest
                              {
                                  PackageId = packageId,
                                  DeliverAddressId = deliveryAddressId
                              };
            var response = this.packagesService.ChangePackageDeliveryAddress(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { Country = Countries.ResourceManager.GetString(response.CountryCode), Message = response.Message, MessageType = response.MessageType.ToString() }
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The change package dispatch method.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="dispatchMethodId">
        /// The dispatch method id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult ChangePackageDispatchMethod(int packageId, int dispatchMethodId)
        {
            var request = new ChangePackageDeliveryMethodRequest { PackageId = packageId, DispatchMethodId = dispatchMethodId };
            var response = this.packagesService.ChangePackageDispatchMethod(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { response.Message, MessageType = response.MessageType.ToString() }
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The assemble package.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult AssemblePackage(int packageId)
        {
            var request = new AssemblePackageRequest { PackageId = packageId };
            var response = this.packagesService.AssemblePackage(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The package assembled.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Operator, Admin")]
        [HttpPost]
        public ActionResult PackageAssembled(int packageId)
        {
            var request = new PackageAssembledRequest { PackageId = packageId };
            var response = this.packagesService.PackageAssembled(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The send package.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult SendPackage(int packageId)
        {
            var request = new SendPackageRequest { PackageId = packageId };
            var response = this.packagesService.SendPackage(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The get users packages.
        /// </summary>
        /// <param name="includeAssembling">
        /// The include assembling.
        /// </param>
        /// <param name="includePaid">
        /// The include paid.
        /// </param>
        /// <param name="includeSent">
        /// The include sent.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin, Operator")]
        [HttpPost]
        public ActionResult GetUsersPackages(bool includeAssembling, bool includePaid, bool includeSent)
        {
            if (!includeAssembling && !includePaid && !includeSent)
            {
                return null;
            }

            var request = new GetUsersPackagesRequest { IncludeAssembling = includeAssembling, IncludePaid = includePaid, IncludeSent = includeSent };
            var response = this.packagesService.GetUsersPackages(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToUsersPackagesViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The update total size.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin, Operator")]
        [HttpPost]
        public ActionResult UpdateTotalSize(PackageSizePopupViewModel model)
        {
            var request = model.ConvertToUpdatePackageTotalSizeRequest();
            var response = this.packagesService.UpdatePackageTotalSize(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToUsersPackagesViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The get shipping rates for package.
        /// </summary>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="girth">
        /// The girth.
        /// </param>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <param name="country">
        /// The country.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin, Operator, Shopper")]
        [HttpPost]
        public ActionResult GetShippingRatesForPackage(decimal height, decimal width, decimal length, decimal girth, int weight, string country)
        {
            var rates = UspsRateCalculator.GetShippingRates(weight, height, length, width, girth, country, "100");
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = rates
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The update tracking number.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="trackingNumber">
        /// The tracking number.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin, Operator")]
        [HttpPost]
        public ActionResult UpdateTrackingNumber(int packageId, string trackingNumber)
        {
            var request = new ChangeTrackingNumberRequest { PackageId = packageId, TrackingNumber = trackingNumber };
            var response = this.packagesService.ChangePackageTrackingNumber(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { response.Message, MessageType = response.MessageType.ToString() }
            };
            return jsonNetResult;
        }
    }
}