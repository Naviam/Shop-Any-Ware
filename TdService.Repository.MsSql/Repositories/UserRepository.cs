// -----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using TdService.Model.Membership;

    /// <summary>
    /// This repository contains methods to work with TD Service users.
    /// </summary>
    public class UserRepository : IUserRepository
    {
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
                return context.Users.Single(u => u.Email == email);
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
        public void AddUser(User user)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update user in the database.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void UpdateUser(User user)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
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
        /// <param name="user">
        /// The user.
        /// </param>
        public void RemoveUser(User user)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}