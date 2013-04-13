// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeRoleRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the FakeRoleRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Account
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Membership;

    /// <summary>
    /// The fake role repository.
    /// </summary>
    public class FakeRoleRepository : IRoleRepository
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
        public Role GetRoleByName(string roleName)
        {
            return null;
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>
        /// Collection of roles.
        /// </returns>
        public IEnumerable<Role> GetAllRoles()
        {
            yield break;
        }

        /// <summary>
        /// Add new role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void AddRole(Role role)
        {
        }

        /// <summary>
        /// Update role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void UpdateRole(Role role)
        {
        }

        /// <summary>
        /// Remove role from DB.
        /// </summary>
        /// <param name="roleId">
        /// The role ID to remove.
        /// </param>
        public void RemoveRole(int roleId)
        {
        }

        /// <summary>
        /// Commit repository changes to DB.
        /// </summary>
        public void SaveChanges()
        {
        }

        /// <summary>
        /// The get role by id.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// The <see cref="Role"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public Role GetRoleById(int roleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add user to role.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public void AddUserToRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove user from role.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Not implemented yet.
        /// </exception>
        public void RemoveUserFromRole(int userId, int roleId)
        {
            throw new NotImplementedException();
        }
    }
}
