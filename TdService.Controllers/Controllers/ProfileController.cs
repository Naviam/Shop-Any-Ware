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
    using System;
    using System.Resources;
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Resources;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.ViewModels;
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
            var profileView = new ProfileView();
            try
            {
                var response = this.membershipService.GetProfile(
                new GetProfileRequest
                    {
                        IdentityToken = this.FormsAuthentication.GetAuthenticationToken()
                    });
                if (response != null)
                {
                    profileView = new ProfileView
                        {
                            Email = response.Email,
                            Id = response.Id,
                            CurrentPassword = response.CurrentPassword,
                            FirstName = response.FirstName,
                            LastName = response.LastName,
                            NotifyOnOrderStatusChange = response.NotifyOnOrderStatusChange,
                            NotifyOnPackageStatusChange = response.NotifyOnPackageStatusChange,
                            MessageType = response.MessageType.ToString().ToLower(),
                            Message = response.Message ?? string.Empty
                        };

                    if (!string.IsNullOrEmpty(response.ErrorCode))
                    {
                        profileView.MessageType = response.MessageType.ToString();
                        profileView.Message =
                            (new ResourceManager(typeof(ErrorCodeResources))).GetString(response.ErrorCode);
                    }

                    ViewData.Model = profileView;
                    return this.View();
                }
            }
            catch (Exception e)
            {
                profileView.Message = e.Message;
                profileView.MessageType = ViewModelMessageType.Error.ToString().ToLower();
                ViewData.Model = profileView;

                return this.View();
            }

            profileView.MessageType = ViewModelMessageType.Error.ToString().ToLower();
            profileView.Message = ErrorCodeResources.ProfileNotFound;
            ViewData.Model = profileView;
            return this.View();
        }

        /// <summary>
        /// Save profile.
        /// </summary>
        /// <param name="profileView">
        /// The profile View.
        /// </param>
        /// <returns>
        /// Returns profile view.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProfileView profileView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var request = new UpdateProfileRequest
                    {
                        FirstName = profileView.FirstName,
                        LastName = profileView.LastName,
                        NotifyOnOrderStatusChanged = profileView.NotifyOnOrderStatusChange,
                        NotifyOnPackageStatusChanged = profileView.NotifyOnPackageStatusChange,
                        IdentityToken = this.FormsAuthentication.GetAuthenticationToken()
                    };

                    var response = this.membershipService.UpdateProfile(request);
                    profileView.Message = response.Message; // ProfileViewResources.UpdateProfileSuccessMessage
                    profileView.MessageType = ViewModelMessageType.Success.ToString().ToLower();
                }
                catch (Exception e)
                {
                    profileView.Message = e.Message;
                    profileView.MessageType = ViewModelMessageType.Error.ToString().ToLower();
                }
            }

            return this.Json(profileView);
        }
    }
}