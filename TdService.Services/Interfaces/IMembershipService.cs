// -----------------------------------------------------------------------
// <copyright file="IMembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using TdService.Services.Messaging.Membership;

    /// <summary>
    /// Interface of membership service.
    /// </summary>
    public interface IMembershipService
    {
        /// <summary>
        /// Sign up shopper.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Sign up shopper response.
        /// </returns>
        RegisterUserResponse SignUpShopper(RegisterUserRequest request);

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Register user response.
        /// </returns>
        RegisterUserResponse RegisterUser(RegisterUserRequest request);

        /// <summary>
        /// Validate user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// True if user valid.
        /// </returns>
        ValidateUserResponse ValidateUser(ValidateUserRequest request);

        /// <summary>
        /// Get user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get user response object.
        /// </returns>
        GetUserResponse GetUser(GetUserRequest request);

        /// <summary>
        /// Get user's profile.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get profile response object.
        /// </returns>
        GetProfileResponse GetProfile(GetProfileRequest request);

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="request">
        /// The update profile request DTO.
        /// </param>
        /// <returns>
        /// The update profile response DTO.
        /// </returns>
        UpdateProfileResponse UpdateProfile(UpdateProfileRequest request);

        /// <summary>
        /// Generate change password link.
        /// </summary>
        /// <param name="request">
        /// The generate change pasword link request.
        /// </param>
        /// <returns>
        /// The response with generated link.
        /// </returns>
        ChangePasswordLinkResponse GenerateChangePasswordLink(ChangePasswordLinkRequest request);
    }
}