// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the ProfileController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Profile controller contains methods to work with user's profile.
    /// </summary>
    public class ProfileController : BaseController
    {
        /// <summary>
        /// Interface for membership service.
        /// </summary>
        private readonly IMembershipService membershipService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileController"/> class.
        /// </summary>
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication service.
        /// </param>
        public ProfileController(IMembershipService membershipService, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
        }

        /// <summary>
        /// Get Profile Summary
        /// </summary>
        /// <returns>
        /// Returns view with the profile details.
        /// </returns>
        public ActionResult Index()
        {
            var profileResponse = this.membershipService.GetProfile(
                new GetProfileRequest
                    {
                        Email = this.FormsAuthentication.GetAuthenticationToken()
                    });

            return this.View(profileResponse.ProfileView);
        }

        /// <summary>
        /// Save full name.
        /// </summary>
        /// <param name="profileView">
        /// The profile View.
        /// </param>
        /// <returns>
        /// Returns profile view.
        /// </returns>
        [HttpPost]
        public ActionResult Save(ProfileView profileView)
        {
            this.membershipService.UpdateProfile(profileView);
            return this.View("Index", profileView);
        }
    }
}