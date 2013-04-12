// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRoleRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The RoleRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System.Collections.Generic;

    /// <summary>
    /// The RoleRepository interface.
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Get role by name.
        /// </summary>
        /// <param name="roleName">
        /// The name of the role.
        /// </param>
        /// <returns>
        /// The role.
        /// </returns>
        Role GetRoleByName(string roleName);

        /// <summary>
        /// The get role by id.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// The <see cref="Role"/>.
        /// </returns>
        Role GetRoleById(int roleId);

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>
        /// Collection of roles.
        /// </returns>
        IEnumerable<Role> GetAllRoles();

        /// <summary>
        /// Add new role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        void AddRole(Role role);

        /// <summary>
        /// Update role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        void UpdateRole(Role role);

        /// <summary>
        /// Remove role from DB.
        /// </summary>
        /// <param name="roleId">
        /// The role ID to remove.
        /// </param>
        void RemoveRole(int roleId);

        /// <summary>
        /// The add user to role.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        void AddUserToRole(int userId, int roleId);

        /// <summary>
        /// The remove user from role.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        void RemoveUserFromRole(int userId, int roleId);

        /// <summary>
        /// Commit repository changes to DB.
        /// </summary>
        void SaveChanges();
    }
}