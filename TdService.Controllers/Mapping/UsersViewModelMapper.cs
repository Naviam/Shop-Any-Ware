// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersViewModelMapper.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The users view model mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;
    using AutoMapper;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Admin;

    /// <summary>
    /// The users view model mapper.
    /// </summary>
    public static class UsersViewModelMapper
    {
        /// <summary>
        /// The convert to users in role view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The collection of users in role view models.
        /// </returns>
        public static List<UsersInRoleViewModel> ConvertToUsersInRoleViewModel(this List<UserResponse> response)
        {
            return Mapper.Map<List<UserResponse>, List<UsersInRoleViewModel>>(response);
        }

        /// <summary>
        /// The convert to users in role view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="UsersInRoleViewModel"/>.
        /// </returns>
        public static UsersInRoleViewModel ConvertToUsersInRoleViewModel(this GetUserByIdResponse response)
        {
            return Mapper.Map<GetUserByIdResponse, UsersInRoleViewModel>(response);
        }

        /// <summary>
        /// The convert to users in role view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="UsersInRoleViewModel"/>.
        /// </returns>
        public static UsersInRoleViewModel ConvertToUsersInRoleViewModel(this GetUserByEmailResponse response)
        {
            return Mapper.Map<GetUserByEmailResponse, UsersInRoleViewModel>(response);
        }
    }
}
