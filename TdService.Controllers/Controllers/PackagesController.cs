// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackagesController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The packages controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Package;
    using TdService.Services.ViewModels.Package;

    using Formatting = System.Xml.Formatting;

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

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageViewModel()
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
            var response = new List<PackageViewModel>
                {
                    new PackageViewModel
                        {
                            Id = 1,
                            CreatedDate = DateTime.UtcNow,
                            Name = "my package 1",
                            Status = "New",
                            DeliveryAddressId = 1,
                            DeliveryAddressName = "my address 1",
                            DispatchMethod = "ExpressDelivery",
                            CanBeRemoved = true,
                            CanBeSent = true,
                            MessageType = "Success"
                        },
                    new PackageViewModel
                        {
                            Id = 2,
                            CreatedDate = DateTime.UtcNow,
                            Name = "my package 2",
                            Status = "New",
                            DeliveryAddressId = 2,
                            DeliveryAddressName = "my address 2",
                            DispatchMethod = "ExpressDelivery",
                            CanBeRemoved = true,
                            CanBeSent = true,
                            MessageType = "Success"
                        }
                };

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response
            };
            return jsonNetResult;
        }
    }
}