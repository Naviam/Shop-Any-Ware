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
    /// <summary>
    /// The RoleRepository interface.
    /// </summary>
    public interface IRoleRepository
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
        Role GetRoleByName(string roleName);

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
        /// Remove role from db.
        /// </summary>
        /// <param name="roleId">
        /// The role ID to remove.
        /// </param>
        void RemoveRole(int roleId);

        /// <summary>
        /// Commit repository changes to db.
        /// </summary>
        void SaveChanges();
    }
}