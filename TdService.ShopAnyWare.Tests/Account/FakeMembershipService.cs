// -----------------------------------------------------------------------
// <copyright file="FakeMembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Membership;

    /// <summary>
    /// Fake membership service for testing purpose.
    /// </summary>
    public class FakeMembershipService : IMembershipService
    {
        /// <summary>
        /// The sign up shopper.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Membership.RegisterUserResponse.
        /// </returns>
        public RegisterUserResponse SignUpShopper(RegisterUserRequest request)
        {
            return null;
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
            var response = new RegisterUserResponse { Email = "1", MessageType = MessageType.Success };
            return response;
        }

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The login user.
        /// </returns>
        public LoginUserResponse LoginUser(LoginUserRequest request)
        {
            return new LoginUserResponse();
        }

        /// <summary>
        /// Validate user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// True if user valid.
        /// </returns>
        public ValidateUserResponse ValidateUser(ValidateUserRequest request)
        {
            return new ValidateUserResponse();
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
            return new GetUserResponse();
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
            return new GetProfileResponse();
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
        /// Update profile.
        /// </summary>
        /// <param name="request">
        /// The update profile request.
        /// </param>
        /// <returns>
        /// The update profile response.
        /// </returns>
        public UpdateProfileResponse UpdateProfile(UpdateProfileRequest request)
        {
            return new UpdateProfileResponse();
        }
    }
}