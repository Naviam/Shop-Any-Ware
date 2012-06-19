﻿// -----------------------------------------------------------------------
// <copyright file="IMembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using TdService.Services.Messaging.Membership;
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Interface of membership service.
    /// </summary>
    public interface IMembershipService
    {
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
        /// Login user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The login user response.
        /// </returns>
        LoginUserResponse LoginUser(LoginUserRequest request);

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
        /// <param name="profileView">
        /// The profile view.
        /// </param>
        /// <returns>
        /// The update profile.
        /// </returns>
        UpdateProfileResponse UpdateProfile(ProfileView profileView);
    }
}