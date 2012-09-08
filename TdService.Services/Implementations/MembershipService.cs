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
    using TdService.Resources;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
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
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The role repository.
        /// </summary>
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// The profile repository.
        /// </summary>
        private readonly IProfileRepository profileRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="roleRepository">
        /// The role repository.
        /// </param>
        /// <param name="profileRepository">
        /// The profile Repository.
        /// </param>
        public MembershipService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IProfileRepository profileRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.profileRepository = profileRepository;
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
            var user = new User(this.userRepository)
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
                var createdUser = this.userRepository.CreateUser(user);
                this.profileRepository.FindOrAddProfile(user.Profile);
                this.userRepository.SaveChanges();
                this.profileRepository.SaveChanges();

                var role = this.roleRepository.GetRoleByName(request.RoleName);
                if (role == null)
                {
                    this.roleRepository.AddRole(new Role { Name = request.RoleName, Description = string.Empty });
                    this.roleRepository.SaveChanges();
                    role = this.roleRepository.GetRoleByName(request.RoleName);
                }

                createdUser.Roles.Add(role);
                this.userRepository.SaveChanges();
            }
            catch (InvalidUserException)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = "EmailExists";
            }

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
            if (this.userRepository.ValidateUser(request.Email, request.Password))
            {
                response.MessageType = MessageType.Success;
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
                    User = this.userRepository.GetUserByEmail(request.IdentityToken),
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
            var user = this.userRepository.GetUserByEmail(request.IdentityToken);
            if (user != null)
            {
                var profile = user.Profile;
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
                            NotifyOnPackageStatusChange = profile.NotifyOnPackageStatusChanged,
                            MessageType = MessageType.Success
                        };

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
            var profile = request.ConvertToProfile();

            ThrowExceptionIfProfileIsInvalid(profile);

            var user = this.userRepository.GetUserByEmail(request.IdentityToken);

            user.Profile.FirstName = profile.FirstName;
            user.Profile.LastName = profile.LastName;
            user.Profile.NotifyOnOrderStatusChanged = profile.NotifyOnOrderStatusChanged;
            user.Profile.NotifyOnPackageStatusChanged = profile.NotifyOnPackageStatusChanged;

            this.userRepository.SaveChanges();

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