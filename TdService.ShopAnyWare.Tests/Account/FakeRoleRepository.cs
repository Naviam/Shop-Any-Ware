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
        /// The name of the rol.
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
        /// Remove role from db.
        /// </summary>
        /// <param name="roleId">
        /// The role ID to remove.
        /// </param>
        public void RemoveRole(int roleId)
        {
        }

        /// <summary>
        /// Commit repository changes to db.
        /// </summary>
        public void SaveChanges()
        {
        }


        public Role GetRoleById(int roleId)
        {
            throw new System.NotImplementedException();
        }


        public void AddUserToRole(int userId, int roleId)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUserFromRole(int userId, int roleId)
        {
            throw new System.NotImplementedException();
        }
    }
}
