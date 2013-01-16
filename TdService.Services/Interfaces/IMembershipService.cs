// -----------------------------------------------------------------------
// <copyright file="IMembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

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
        SignUpResponse SignUpShopper(SignUpRequest request);

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Register user response.
        /// </returns>
        SignUpResponse RegisterUser(SignUpRequest request);

        /// <summary>
        /// Validate user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// True if user valid.
        /// </returns>
        SignInResponse SignIn(SignInRequest request);

        /// <summary>
        /// The get user roles.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The Get user roles response collection.
        /// </returns>
        List<GetUserRolesResponse> GetUserRoles(GetUserRolesRequest request);

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
        /// The generate change password link.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Membership.ChangePasswordLinkResponse.
        /// </returns>
        ChangePasswordLinkResponse GenerateChangePasswordLink(ChangePasswordLinkRequest request);

        /// <summary>
        /// Gets users in role
        /// </summary>
        /// <param name="request">The GetUsersInRoleRequest request. Pass role ID as '-1' to get all users</param>
        /// <returns>GetUsersInRole Response</returns>
        GetUsersInRoleResponse GetUsersInRole(GetUsersInRoleRequest request);

        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="request">ID</param>
        /// <returns>user</returns>
        GetUserByIdResponse GetUserById(GetUserByIdRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddUserToRoleResponse AddUserToRole(AddUserToRoleRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RemoveUserFromRoleResponse RemoveUserFromRole(RemoveUserFromRoleRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        List<GetAllRolesResponse> GetAllRoles(GetAllRolesRequest request);
    }
}