// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The role repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using TdService.Model.Membership;

    /// <summary>
    /// The role repository.
    /// </summary>
    public class RoleRepository : IRoleRepository, IDisposable
    {
        /// <summary>
        /// Shop any ware DB context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public RoleRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

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
            return this.context.Roles.SingleOrDefault(r => r.Name == roleName);
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>
        /// Collection of roles.
        /// </returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return this.context.Roles.ToList();
        }

        /// <summary>
        /// Add new role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void AddRole(Role role)
        {
            this.context.Roles.Add(role);
        }

        /// <summary>
        /// Update role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void UpdateRole(Role role)
        {
            this.context.Entry(role).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove role from DB.
        /// </summary>
        /// <param name="roleId">
        /// The role ID to remove.
        /// </param>
        public void RemoveRole(int roleId)
        {
            var role = this.context.Roles.Find(roleId);
            if (role != null)
            {
                this.context.Roles.Remove(role);
            }
        }

        /// <summary>
        /// Commit repository changes to DB.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.context.Dispose();
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
        public Role GetRoleById(int roleId)
        {
            var result = this.context.Roles.Find(roleId);
            return result;
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
        public void AddUserToRole(int userId, int roleId)
        {
            var role = this.GetRoleById(roleId);
            var user = this.context.Users.Include("Roles").Include("Profile").Include("Wallet").SingleOrDefault(u => u.Id.Equals(userId));
            if (user != null)
            {
                user.AddUserToRole(role);
            }
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
        public void RemoveUserFromRole(int userId, int roleId)
        {
            var user = this.context.Users.Include("Roles").Include("Profile").Include("Wallet").SingleOrDefault(u => u.Id.Equals(userId));
            if (user != null)
            {
                user.RemoveUserFromRole(roleId);
            }
        }
    }
}