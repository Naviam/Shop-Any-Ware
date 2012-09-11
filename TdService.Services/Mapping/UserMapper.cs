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
        public static RegisterUserResponse ConvertToRegisterUserResponse(this User user)
        {
            return Mapper.Map<User, RegisterUserResponse>(user);
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
        public static User ConvertToUser(this RegisterUserRequest request)
        {
            return Mapper.Map<RegisterUserRequest, User>(request);
        }
    }
}