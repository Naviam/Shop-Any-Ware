﻿// -----------------------------------------------------------------------
// <copyright file="MembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System.Linq;
    using System.Text;

    using TdService.Model.Membership;
    using TdService.Model.Notification;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.ViewModels.Account;

    using Profile = TdService.Model.Membership.Profile;

    /// <summary>
    /// Membership service class.
    /// </summary>
    public class MembershipService : IMembershipService
    {
        /// <summary>
        /// Membership repository.
        /// </summary>
        private readonly IMembershipRepository membershipRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipService"/> class.
        /// </summary>
        /// <param name="membershipRepository">
        /// The membership repository.
        /// </param>
        public MembershipService(IMembershipRepository membershipRepository)
        {
            this.membershipRepository = membershipRepository;
        }

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Register user response.
        /// </returns>
        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            var response = new RegisterUserResponse();
            var user = new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    Profile = new Profile { FirstName = request.FirstName, LastName = request.LastName }
                };
            return response;
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        public void LoginUser(LoginUserRequest request)
        {
        }

        /// <summary>
        /// Validate user against database.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// True if user exists in db, otherwise false.
        /// </returns>
        public bool ValidateUser(ValidateUserRequest request)
        {
            return this.membershipRepository.ValidateUser(request.Email, request.Password);
        }

        /// <summary>
        /// Get user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get user response object.
        /// </returns>
        public GetUserResponse GetUser(GetUserRequest request)
        {
            var response = new GetUserResponse { User = this.membershipRepository.GetUser(request.Email) };
            return response;
        }

        /// <summary>
        /// Get user's profile.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get profile response object.
        /// </returns>
        public GetProfileResponse GetProfile(GetProfileRequest request)
        {
            var response = new GetProfileResponse();
            var user = this.membershipRepository.GetUser(request.Email);
            var profile = user.Profile;
            response.ProfileView = new ProfileView
                {
                    Email = user.Email,
                    CurrentPassword = user.Password,
                    Id = (profile == null) ? 0 : profile.Id,
                    FirstName = (profile == null) ? string.Empty : profile.FirstName,
                    LastName = (profile == null) ? string.Empty : profile.LastName
                };
            if (profile != null)
            {
                if (profile.NotificationRule != null)
                {
                    response.ProfileView.NotifyOnOrderStatusChange = 
                        profile.NotificationRule.NotifyOrderStatusChanged;
                    response.ProfileView.NotifyOnPackageStatusChange =
                        profile.NotificationRule.NotifyParcelStatusChanged;
                }
            }
            return response;
        }

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="profileView">
        /// The profile view.
        /// </param>
        public void UpdateProfile(ProfileView profileView)
        {
            var profile = new Profile
                {
                    FirstName = profileView.FirstName,
                    LastName = profileView.LastName,
                    NotificationRule =
                        new NotificationRule
                            {
                                NotifyOrderStatusChanged = profileView.NotifyOnOrderStatusChange,
                                NotifyParcelStatusChanged = profileView.NotifyOnPackageStatusChange
                            }
                };

            this.ThrowExceptionIfProfileIsInvalid(profile);

            this.membershipRepository.UpdateProfile(profileView.Email, profile);
        }

        /// <summary>
        /// Validates profile.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <exception cref="InvalidProfileException">
        /// Thrown when business rules are broken.
        /// </exception>
        private void ThrowExceptionIfProfileIsInvalid(Profile profile)
        {
            if (profile.GetBrokenRules().Any())
            {
                var profileIssues = new StringBuilder();
                profileIssues.AppendLine(
                    "There were some issues with the profile you are editing.");

                foreach (var rule in profile.GetBrokenRules())
                {
                    profileIssues.AppendLine(rule.Rule);
                }

                throw new InvalidProfileException(profileIssues.ToString());
            }
        }
    }
}