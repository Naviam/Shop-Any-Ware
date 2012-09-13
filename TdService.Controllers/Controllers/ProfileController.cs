// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the ProfileController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Xml;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Domain;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Account;

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
        [Authorize]
        public ActionResult Index()
        {
            var response = this.membershipService.GetProfile(
                new GetProfileRequest
                {
                    IdentityToken = this.FormsAuthentication.GetAuthenticationToken()
                });
            var result = response.ConvertToProfileViewModel();
            this.ViewData.Model = result;
            return this.View();
        }

        /// <summary>
        /// Save profile.
        /// </summary>
        /// <param name="model">
        /// The profile View.
        /// </param>
        /// <returns>
        /// Returns profile view.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken(Salt = "Profile")]
        public ActionResult Save(ProfileViewModel model)
        {
            var result = new ProfileViewModel();
            var validator = new ProfileViewModelValidator();
            var validationResult = validator.Validate(model);

            if (validationResult.IsValid)
            {
                var request = model.ConvertToUpdateProfileRequest();
                request.IdentityToken = this.FormsAuthentication.GetAuthenticationToken();
                var response = this.membershipService.UpdateProfile(request);
                result = response.ConvertToProfileViewModel();
            }
            else
            {
                result.MessageType = MessageType.Warning.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.ErrorMessage));
                }
            }

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }
    }
}