﻿// -----------------------------------------------------------------------
// <copyright file="IMembershipRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System.Collections.Generic;

    using TdService.Model.Addresses;

    /// <summary>
    /// Interface for membership repository (roles, users and profile).
    /// </summary>
    public interface IMembershipRepository
    {
        #region Profile
        /// <summary>
        /// Get user's profile.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// User's profile.
        /// </returns>
        Profile GetProfile(string email);

        /// <summary>
        /// Get warehouse address for user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// Warehouse address for user.
        /// </returns>
        WarehouseAddress GetWarehouseAddress(string email);

        /// <summary>
        /// Change user's password.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="oldPassword">
        /// The old password.
        /// </param>
        /// <param name="newPassword">
        /// The new password.
        /// </param>
        /// <returns>
        /// True if password was changed, otherwise false.
        /// </returns>
        bool ChangePassword(string email, string oldPassword, string newPassword);

        /// <summary>
        /// Update profile of the user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="profile">
        /// The profile.
        /// </param>
        void UpdateProfile(string email, Profile profile);
        #endregion

        #region Roles
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
        /// Add users in role.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        /// <param name="role">
        /// The role.
        /// </param>
        void AddUsersInRole(List<User> users, Role role);

        /// <summary>
        /// Get user's roles.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// User's roles.
        /// </returns>
        IEnumerable<Role> GetUserRoles(string email);

        /// <summary>
        /// Remove users from role.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        void RemoveUsersFromRole(List<User> users, string roleName);

        /// <summary>
        /// Get roles.
        /// </summary>
        /// <returns>
        /// All application roles.
        /// </returns>
        IEnumerable<Role> GetRoles();
        #endregion

        #region Users
        /// <summary>
        /// Get user by name.
        /// </summary>
        /// <param name="email">
        /// The user's email.
        /// </param>
        /// <returns>
        /// User object.
        /// </returns>
        User GetUser(string email);

        /// <summary>
        /// Validate user credentials.
        /// </summary>
        /// <param name="email">
        /// The user's email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Boolean value that indicates the result of validation.
        /// </returns>
        bool ValidateUser(string email, string password);

        /// <summary>
        /// Add new user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        void AddUser(User user);

        /// <summary>
        /// Update user's email in the database.
        /// </summary>
        /// <param name="oldEmail">
        /// The old Email.
        /// </param>
        /// <param name="newEmail">
        /// The new Email.
        /// </param>
        void UpdateUserEmail(string oldEmail, string newEmail);

        /// <summary>
        /// Get users sorted by email ascending.
        /// </summary>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// Collection of users.
        /// </returns>
        IEnumerable<User> GetUsersSortedByEmailAsc(int pageSize = 20);

        /// <summary>
        /// Remove user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        void RemoveUser(string email);

        #endregion
    }
}