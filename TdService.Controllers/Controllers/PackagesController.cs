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
    using TdService.Services.ViewModels.Package;

    /// <summary>
    /// The packages controller.
    /// </summary>
    public class PackagesController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackagesController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public PackagesController(IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
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
            return this.Json(response);
        }
    }
}