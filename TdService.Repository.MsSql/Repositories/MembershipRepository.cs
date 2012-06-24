// -----------------------------------------------------------------------
// <copyright file="MembershipRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using TdService.Model.Addresses;
    using TdService.Model.Membership;
    using TdService.Model.Notification;

    /// <summary>
    /// This repository contains methods to work with users and roles.
    /// </summary>
    public class MembershipRepository : IMembershipRepository
    {
        #region Users
        /// <summary>
        /// Get user by email.
        /// </summary>
        /// <param name="email">
        /// The user's email.
        /// </param>
        /// <returns>
        /// User object.
        /// </returns>
        public User GetUser(string email)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("Profile").SingleOrDefault(u => u.Email == email);
                return user;
            }
        }

        /// <summary>
        /// Validate the email and password combination exists in the database.
        /// </summary>
        /// <param name="email">
        /// The user's email.
        /// </param>
        /// <param name="password">
        /// The user's password.
        /// </param>
        /// <returns>
        /// True when user exists and false when it does not.
        /// </returns>
        public bool ValidateUser(string email, string password)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u =>
                    (string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(u.Password, password, StringComparison.Ordinal) == 0));
                return user != null;
            }
        }

        /// <summary>
        /// Add new user to database.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void AddShopper(User user)
        {
            using (var context = new ShopAnyWareSql())
            {
                var role = context.Roles.SingleOrDefault(r => r.Name == "Shopper");
                context.Roles.Attach(role);
                context.Users.Add(user);
                context.SaveChanges();

                // user.Profile = new Profile { FirstName = user.Profile.FirstName, LastName = user.Profile.LastName };
                // context.Entry(user).State = EntityState.Modified;
                // context.SaveChanges();

                // var profile = context.Profiles.Find(user.Profile.Id);
                // profile.NotificationRule = new NotificationRule
                // {
                //     NotifyOnOrderStatusChanged = true,
                //     NotifyOnPackageStatusChanged = true
                // };
                // context.NotificationRules.Attach(profile.NotificationRule);
                // context.Entry(profile).State = EntityState.Modified;
                // context.SaveChanges();
            }
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
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == oldEmail);
                if (user != null)
                {
                    user.Email = newEmail;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Get users acsending sorted by email.
        /// </summary>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// Collection of users.
        /// </returns>
        public IEnumerable<User> GetUsersSortedByEmailAsc(int pageSize = 20)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Users.OrderBy(u => u.Email);
            }
        }

        /// <summary>
        /// Remove user from database.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        public void RemoveUser(string email)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u => u.Email == email);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        } 
        #endregion

        #region Profile

        /// <summary>
        /// Get user's profile by id.
        /// </summary>
        /// <param name="id">
        /// The profile id.
        /// </param>
        /// <returns>
        /// User's profile.
        /// </returns>
        public Profile GetProfile(int id)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Profiles.Include("NotificationRule").SingleOrDefault(p => p.Id == id);
            }
        }

        /// <summary>
        /// Get U.S. warehouse address.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// Warehouse address.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        public WarehouseAddress GetWarehouseAddress(string email)
        {
            throw new NotImplementedException();
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
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u =>
                    (string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(u.Password, oldPassword, StringComparison.Ordinal) == 0));
                if (user != null)
                {
                    user.Password = newPassword;
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Update first and last name of the user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="profile">
        /// The profile.
        /// </param>
        public void UpdateProfile(string email, Profile profile)
        {
            using (var context = new ShopAnyWareSql())
            {
                var profileDb = context.Users
                    .Where(u => string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0)
                    .Select(u => u.Profile).SingleOrDefault();
                if (profileDb != null)
                {
                    profileDb.FirstName = profile.FirstName;
                    profileDb.LastName = profile.LastName;
                    if (profile.NotificationRule != null)
                    {
                        profileDb.NotificationRule = new NotificationRule
                        {
                            NotifyOnOrderStatusChanged = profile.NotificationRule.NotifyOnOrderStatusChanged,
                            NotifyOnPackageStatusChanged = profile.NotificationRule.NotifyOnPackageStatusChanged
                        };
                    }

                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Roles
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
                return context.Roles.Find(roleId);
            }
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
            using (var context = new ShopAnyWareSql())
            {
                return context.Roles.Single(r => r.Name == roleName);
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

        /// <summary>
        /// Add users in role.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="roleName">
        /// The name of role.
        /// </param>
        public void AddUserInRole(User user, string roleName)
        {
            using (var context = new ShopAnyWareSql())
            {
                var role = this.GetRole(roleName);
                context.Roles.Attach(role);
                role.Users.Add(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get roles for user.
        /// </summary>
        /// <param name="email">
        /// The user's email.
        /// </param>
        /// <returns>
        /// Collection of roles.
        /// </returns>
        public IEnumerable<Role> GetUserRoles(string email)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.SingleOrDefault(u => string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0);
                return (user != null) ? user.Roles : new List<Role>();
            }
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
            using (var context = new ShopAnyWareSql())
            {
                var role = context.Roles.SingleOrDefault(r => string.Compare(r.Name, roleName, StringComparison.OrdinalIgnoreCase) == 0);
                if (role != null)
                {
                    role.Users.RemoveAll(u => u.Roles.Contains(role));
                    context.SaveChanges();
                }
            }
        } 
        #endregion
    }
}