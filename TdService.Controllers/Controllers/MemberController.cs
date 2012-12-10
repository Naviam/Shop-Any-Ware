// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the MemberController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Address;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Member;

    /// <summary>
    /// The controller that contains membership methods.
    /// </summary>
    public class MemberController : BaseAuthController
    {
        /// <summary>
        /// The membership service.
        /// </summary>
        private readonly IMembershipService membershipService;

        private readonly IAddressService addressService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        /// <param name="addressService">
        /// The address service.
        /// </param>
        public MemberController(IFormsAuthentication formsAuthentication, IMembershipService membershipService, IAddressService addressService)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
            this.addressService = addressService;
        }

        /// <summary>
        /// Testing the new interface.
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult Dashboard()
        {
            var model = new ShopperDashboardViewModel();
            var response = this.membershipService.GetProfile(
                new GetProfileRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
            model.UserId = response.Id;
            model.FirstName = response.FirstName;
            model.LastName = response.LastName;

            var addressesResponse = this.addressService.GetDeliveryAddresses(new GetDeliveryAddressesRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
            model.DeliveryAddressViewModels = addressesResponse.ConvertToDeliveryAddressViewModel();

            model.DeliveryMethods = new List<string> { "Standard Delivery", "Express Delivery" };

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// Welcome page after successful registration.
        /// </summary>
        /// <returns>
        /// View with welcome message.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult Welcome()
        {
            var model = new WelcomeViewModel();
            var response = this.membershipService.GetProfile(
                new GetProfileRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
            model.UserId = response.Id;
            model.FirstName = response.FirstName;
            model.LastName = response.LastName;

            return this.View("Welcome", model);
        }

        [Authorize(Roles = "Shopper")]
        public ActionResult Deposit()
        {
            return this.View("Deposit");
        }

        [Authorize(Roles = "Shopper")]
        public ActionResult ConfirmDeposit(string token, string payerId)
        {
            return this.View("ConfirmDeposit");
        }

        [Authorize(Roles = "Shopper")]
        public ActionResult DepositCanceled()
        {
            return this.View("DepositCanceled");
        }
    }
}