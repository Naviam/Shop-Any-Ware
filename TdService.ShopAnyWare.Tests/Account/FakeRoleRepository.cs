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
    }
}
