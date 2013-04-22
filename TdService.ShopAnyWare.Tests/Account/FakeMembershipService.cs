// -----------------------------------------------------------------------
// <copyright file="FakeMembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using System;
    using System.Collections.Generic;

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
        public SignUpResponse SignUpShopper(SignUpRequest request)
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
        public SignUpResponse RegisterUser(SignUpRequest request)
        {
            var response = new SignUpResponse { Email = "1", MessageType = MessageType.Success };
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
        public SignInResponse SignIn(SignInRequest request)
        {
            return new SignInResponse();
        }

        /// <summary>
        /// The get user roles.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of get user roles responses.
        /// </returns>
        List<GetUserRolesResponse> IMembershipService.GetUserRoles(GetUserRolesRequest request)
        {
            return null;
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

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetUserByIdResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public GetUserByIdResponse GetUserById(GetUserByIdRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get users in role.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetUsersInRoleResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        GetUsersInRoleResponse IMembershipService.GetUsersInRole(GetUsersInRoleRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add user to role.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="AddUserToRoleResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public AddUserToRoleResponse AddUserToRole(AddUserToRoleRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove user from role.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="RemoveUserFromRoleResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public RemoveUserFromRoleResponse RemoveUserFromRole(RemoveUserFromRoleRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all roles.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of get all roles responses.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented exception.
        /// </exception>
        List<GetAllRolesResponse> IMembershipService.GetAllRoles(GetAllRolesRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get user by email.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetUserByEmailResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public GetUserByEmailResponse GetUserByEmail(GetUserByEmailRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The sign up admin.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SignUpAdminResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public SignUpAdminResponse SignUpAdmin(SignUpAdminRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The activate email.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ActivateUserEmailResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public ActivateUserEmailResponse ActivateEmail(ActivateUserEmailRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The reset password.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ResetPasswordResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// not implemented
        /// </exception>
        public ResetPasswordResponse ResetPassword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The change password.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ChangePasswordResponse"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// not implemented
        /// </exception>
        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }


        public ChangeUserCultureResponse ChangeUserUiCulture(ChangeUserCultureRequest request)
        {
            throw new NotImplementedException();
        }
    }
}