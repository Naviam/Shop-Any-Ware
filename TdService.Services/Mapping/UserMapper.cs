// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserMapper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The user mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Model.Membership;
    using TdService.Services.Messaging.Membership;

    /// <summary>
    /// The user mapper.
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// The convert to get delivery addresses response.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Membership.RegisterUserResponse.
        /// </returns>
        public static SignUpResponse ConvertToRegisterUserResponse(this User user)
        {
            return Mapper.Map<User, SignUpResponse>(user);
        }

        /// <summary>
        /// The convert to user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Model.Membership.User.
        /// </returns>
        public static User ConvertToUser(this SignUpRequest request)
        {
            return Mapper.Map<SignUpRequest, User>(request);
        }

        /// <summary>
        /// The convert to get user roles response collection.
        /// </summary>
        /// <param name="roles">
        /// The roles.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Services.Messaging.Membership.GetUserRolesResponse].
        /// </returns>
        public static List<GetUserRolesResponse> ConvertToGetUserRolesResponseCollection(this List<Role> roles)
        {
            return Mapper.Map<List<Role>, List<GetUserRolesResponse>>(roles);
        }

        /// <summary>
        /// The convert to get users in role response collection.
        /// </summary>
        /// <param name="users">
        /// The roles.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Services.Messaging.Membership.GetUserRolesResponse].
        /// </returns>
        public static List<TdService.Services.Messaging.Membership.GetUsersInRoleResponse.UserResponseModel> ConvertToGetUsersInRoleResponseCollection(this List<User> users)
        {
            var result = Mapper.Map<List<User>, List<TdService.Services.Messaging.Membership.GetUsersInRoleResponse.UserResponseModel>>(users);
            return result;
        }

        /// <summary>
        /// The convert to get user by id response.
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>GetUserByIdResponse</returns>
        public static GetUserByIdResponse ConvertToGetUserByIdResponse(this User user)
        {
            var result = Mapper.Map<User, GetUserByIdResponse>(user);
            return result;
        }
    }
}