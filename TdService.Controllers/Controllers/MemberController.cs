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
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Implementations;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Member;

    /// <summary>
    /// The controller that contains membership methods.
    /// </summary>
    public class MemberController : BaseAuthController
    {
        /// <summary>
        /// The membership service.
        /// </summary>
        private readonly MembershipService membershipService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        public MemberController(IFormsAuthentication formsAuthentication, MembershipService membershipService)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
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

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// Welcome page after successfull registration.
        /// </summary>
        /// <returns>
        /// View with welcome message.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult Welcome()
        {
            return this.View("Welcome");
        }
    }
}