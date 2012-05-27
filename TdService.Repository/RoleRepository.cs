// -----------------------------------------------------------------------
// <copyright file="RoleRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Data.SqlRepository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using TdService.Model.Membership;

    /// <summary>
    /// This repository contains methods to work with user roles.
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        /// <summary>
        /// Add new role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void AddRole(Role role)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Remove role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void RemoveRole(Role role)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Roles.Remove(role);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void UpdateRole(Role role)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get role by id.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// Role object.
        /// </returns>
        public Role GetRole(int roleId)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Roles.Single(r => r.Id == roleId);
            }
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>
        /// Collection of roles.
        /// </returns>
        public IEnumerable<Role> GetRoles()
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Roles;
            }
        }

        public void AddUserInRoles(User user, IEnumerable<Role> roles)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> GetUserRoles(string username)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUserFromRoles(User user, IEnumerable<Role> roles)
        {
            throw new System.NotImplementedException();
        }
    }
}