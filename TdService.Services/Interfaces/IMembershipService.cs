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
        /// Mark user pwd as forgotten and send email with link to reset it.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Membership.ChangePasswordLinkResponse.
        /// </returns>
        ResetPasswordResponse ResetPassword(ResetPasswordRequest request);

        /// <summary>
        /// Gets users in role
        /// </summary>
        /// <param name="request">The GetUsersInRoleRequest request. Pass role ID as '-1' to get all users</param>
        /// <returns>GetUsersInRole Response</returns>
        GetUsersInRoleResponse GetUsersInRole(GetUsersInRoleRequest request);

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetUserByIdResponse"/>.
        /// </returns>
        GetUserByIdResponse GetUserById(GetUserByIdRequest request);

        /// <summary>
        /// The add user to role.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="AddUserToRoleResponse"/>.
        /// </returns>
        AddUserToRoleResponse AddUserToRole(AddUserToRoleRequest request);

        /// <summary>
        /// The remove user from role.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="RemoveUserFromRoleResponse"/>.
        /// </returns>
        RemoveUserFromRoleResponse RemoveUserFromRole(RemoveUserFromRoleRequest request);

        /// <summary>
        /// The get all roles.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of get all roles responses.
        /// </returns>
        List<GetAllRolesResponse> GetAllRoles(GetAllRolesRequest request);

        /// <summary>
        /// The get user by email.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetUserByEmailResponse"/>.
        /// </returns>
        GetUserByEmailResponse GetUserByEmail(GetUserByEmailRequest request);

        /// <summary>
        /// The sign up admin.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SignUpAdminResponse"/>.
        /// </returns>
        SignUpAdminResponse SignUpAdmin(SignUpAdminRequest request);

        /// <summary>
        /// The activate email.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ActivateUserEmailResponse"/>.
        /// </returns>
        ActivateUserEmailResponse ActivateEmail(ActivateUserEmailRequest request);

        /// <summary>
        /// Change users pwd
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);

        /// <summary>
        /// Changes user's culture to specify what resx files to use when sending emails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeUserCultureResponse ChangeUserUiCulture(ChangeUserCultureRequest request);
    }
}