// -----------------------------------------------------------------------
// <copyright file="MembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Text;

    using TdService.Model.Balance;
    using TdService.Model.Membership;
    using TdService.Resources;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Membership;

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
            var user = new User(this.membershipRepository)
                {
                    Email = request.Email,
                    Password = request.Password,
                    Profile = new Profile
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            NotifyOnOrderStatusChanged = true,
                            NotifyOnPackageStatusChanged = true
                        }
                };

            try
            {
                ThrowExceptionIfUserIsInvalid(user);
            }
            catch (InvalidUserException)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = "EmailExists";
            }

            // var userInDatabase = this.membershipRepository.GetUser(request.Email);
            // if (userInDatabase != null)
            // {
            // response.MessageType = MessageType.Error;
            // response.ErrorCode = "EmailExists";
            // }
            // else
            // {
                this.membershipRepository.AddShopper(user);

                // var createdUser = this.membershipRepository.GetUser(user.Email);
                // if (createdUser != null)
                // {
                // if (createdUser.Profile != null)
                // {
                // var profile = this.membershipRepository.GetProfile(createdUser.Profile.Id);
                // }
                // }
            // }
            return response;
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
        public ValidateUserResponse ValidateUser(ValidateUserRequest request)
        {
            var response = new ValidateUserResponse();
            if (this.membershipRepository.ValidateUser(request.Email, request.Password))
            {
                response.Message = MembershipResources.ValidationSuccess;
                return response;
            }

            response.ErrorCode = "NotValidUser";
            return response;
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
            var response = new GetUserResponse
                {
                    User = this.membershipRepository.GetUser(request.IdentityToken),
                    MessageType = MessageType.Success
                };
            if (response.User == null)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = "UserNotFound";
            }

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
            var user = this.membershipRepository.GetUser(request.IdentityToken);
            if (user != null)
            {
                var profile = this.membershipRepository.GetProfile(user.Profile.Id);
                if (profile != null)
                {
                    response = new GetProfileResponse
                    {
                        FirstName = profile.FirstName,
                        LastName = profile.LastName,
                        Id = profile.Id,
                        Email = user.Email,
                        CurrentPassword = user.Password,
                        NotifyOnOrderStatusChange = profile.NotifyOnOrderStatusChanged,
                        NotifyOnPackageStatusChange = profile.NotifyOnPackageStatusChanged
                    };

                    response.MessageType = MessageType.Success;
                    return response;
                }

                response.MessageType = MessageType.Error;
                response.ErrorCode = "ProfileNotFound";
                return response;
            }

            response.MessageType = MessageType.Error;
            response.ErrorCode = "UserNotFound";
            return response;
        }

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="request">
        /// The update profile request.
        /// </param>
        /// <returns>
        /// The update profile.
        /// </returns>
        public UpdateProfileResponse UpdateProfile(UpdateProfileRequest request)
        {
            var response = new UpdateProfileResponse();
            var profile = new Profile
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    NotifyOnOrderStatusChanged = request.NotifyOnOrderStatusChanged,
                    NotifyOnPackageStatusChanged = request.NotifyOnPackageStatusChanged
                };

            ThrowExceptionIfProfileIsInvalid(profile);

            this.membershipRepository.UpdateProfile(request.IdentityToken, profile);

            response.MessageType = MessageType.Success;
            response.Message = Resources.Views.ProfileViewResources.UpdateProfileSuccessMessage;
            return response;
        }

        /// <summary>
        /// Generate change password link.
        /// </summary>
        /// <param name="request">
        /// The generate change pasword link request.
        /// </param>
        /// <returns>
        /// The response with generated link.
        /// </returns>
        public ChangePasswordLinkResponse GenerateChangePasswordLink(ChangePasswordLinkRequest request)
        {
            return null;
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
        private static void ThrowExceptionIfProfileIsInvalid(Profile profile)
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

        /// <summary>
        /// Throw exception if user is invalid.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <exception cref="InvalidUserException">
        /// Thrown when business rules are broken.
        /// </exception>
        private static void ThrowExceptionIfUserIsInvalid(User user)
        {
            if (user.GetBrokenRules().Any())
            {
                var issues = new StringBuilder();

                // issues.AppendLine("There were some issues.");
                foreach (var rule in user.GetBrokenRules())
                {
                    issues.AppendLine(rule.Rule);
                }

                throw new InvalidUserException(issues.ToString());
            }
        }
    }
}