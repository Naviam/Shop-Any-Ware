// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeMembershipRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Fake membership repository for testing purpose.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Services
{
    using System.Collections.Generic;

    using TdService.Model.Addresses;
    using TdService.Model.Membership;

    /// <summary>
    /// Fake membership repository for testing purpose.
    /// </summary>
    public class FakeMembershipRepository : IMembershipRepository
    {
        /// <summary>
        /// Get user's profile.
        /// </summary>
        /// <param name="id">
        /// The profile id.
        /// </param>
        /// <returns>
        /// User's profile.
        /// </returns>
        public Profile GetProfile(int id)
        {
            if (id == 1)
            {
                return new Profile
                    {
                        Id = id,
                        FirstName = "Vitali",
                        LastName = "Hatalski",
                        NotifyOnOrderStatusChanged = true,
                        NotifyOnPackageStatusChanged = true
                    };
            }

            return null;
        }

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
        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            return false;
        }

        /// <summary>
        /// Update profile of the user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="profile">
        /// The profile.
        /// </param>
        public void UpdateProfile(string email, Profile profile)
        {
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
        /// Remove role.
        /// </summary>
        /// <param name="role">
        /// The role.
        /// </param>
        public void RemoveRole(Role role)
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
        /// Get role by id.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// Application role.
        /// </returns>
        public Role GetRole(int roleId)
        {
            return null;
        }

        /// <summary>
        /// Get role by name.
        /// </summary>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        /// <returns>
        /// Role object.
        /// </returns>
        public Role GetRole(string roleName)
        {
            return null;
        }

        /// <summary>
        /// Add users in role.
        /// </summary>
        /// <param name="user">
        /// The users.
        /// </param>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        public void AddUserInRole(User user, string roleName)
        {
        }

        /// <summary>
        /// Get user's roles.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// User's roles.
        /// </returns>
        public IEnumerable<Role> GetUserRoles(string email)
        {
            yield break;
        }

        /// <summary>
        /// Remove users from role.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        public void RemoveUsersFromRole(List<User> users, string roleName)
        {
        }

        /// <summary>
        /// Get roles.
        /// </summary>
        /// <returns>
        /// All application roles.
        /// </returns>
        public IEnumerable<Role> GetRoles()
        {
            yield break;
        }

        /// <summary>
        /// Get user by name.
        /// </summary>
        /// <param name="email">
        /// The user's email.
        /// </param>
        /// <returns>
        /// User object.
        /// </returns>
        public User GetUser(string email)
        {
            if (email == "vhatalski@naviam.com")
            {
                var user = new User(this)
                    {
                        Email = email,
                        Profile =
                            new Profile
                                {
                                    Id = 1,
                                    FirstName = "Vitali",
                                    LastName = "Hatalski",
                                    NotifyOnOrderStatusChanged = true,
                                    NotifyOnPackageStatusChanged = true
                                }
                    };

                return user;
            }

            return null;
        }

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
        public bool ValidateUser(string email, string password)
        {
            return false;
        }

        /// <summary>
        /// Add new user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void AddShopper(User user)
        {
        }

        /// <summary>
        /// Update user's email in the database.
        /// </summary>
        /// <param name="oldEmail">
        /// The old Email.
        /// </param>
        /// <param name="newEmail">
        /// The new Email.
        /// </param>
        public void UpdateUserEmail(string oldEmail, string newEmail)
        {
        }

        /// <summary>
        /// Get users sorted by email ascending.
        /// </summary>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// Collection of users.
        /// </returns>
        public IEnumerable<User> GetUsersSortedByEmailAsc(int pageSize = 20)
        {
            yield break;
        }

        /// <summary>
        /// Remove user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        public void RemoveUser(string email)
        {
        }
    }
}