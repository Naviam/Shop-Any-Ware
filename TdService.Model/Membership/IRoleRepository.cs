// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRoleRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Interface for user role repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for user role repository.
    /// </summary>
    public interface IRoleRepository 
    {
        /// <summary>
        /// Add new role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        void AddRole(Role role);

        /// <summary>
        /// Remove role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        void RemoveRole(Role role);

        /// <summary>
        /// Update role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        void UpdateRole(Role role);

        /// <summary>
        /// Get role by id.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// Application role.
        /// </returns>
        Role GetRole(int roleId);

        /// <summary>
        /// Add users to roles.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="roles">
        /// The roles.
        /// </param>
        void AddUserInRoles(User user, IEnumerable<Role> roles);

        /// <summary>
        /// Get user's roles.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// User's roles.
        /// </returns>
        IEnumerable<Role> GetUserRoles(string username);

        /// <summary>
        /// Remove user from roles.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="roles">
        /// The roles.
        /// </param>
        void RemoveUserFromRoles(User user, IEnumerable<Role> roles);

        /// <summary>
        /// Get roles.
        /// </summary>
        /// <returns>
        /// All application roles.
        /// </returns>
        IEnumerable<Role> GetRoles();
    }
}