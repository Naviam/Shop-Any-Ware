// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   User repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Data;
    using System.Linq;

    using TdService.Model.Membership;

    /// <summary>
    /// User repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Shop any ware db context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public UserRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get user by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user.
        /// </returns>
        public User GetUserByEmail(string email)
        {
            return this.context.Users.Include("Profile").Include("Roles").SingleOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Get user with orders by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user.
        /// </returns>
        public User GetUserWithOrdersByEmail(string email)
        {
            return this.context.Users.Include("Profile").Include("Orders").Include("Roles").SingleOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Validate user against db.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The boolean value.
        /// </returns>
        public bool ValidateUser(string email, string password)
        {
            var user = this.context.Users.SingleOrDefault(u =>
                    (string.Compare(u.Email, email, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(u.Password, password, StringComparison.Ordinal) == 0));
            return user != null;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// Created user.
        /// </returns>
        public User CreateUser(User user)
        {
            return this.context.Users.Add(user);
        }

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="user">
        /// The user to update.
        /// </param>
        public void UpdateUser(User user)
        {
            this.context.Entry(user).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove user by user id.
        /// </summary>
        /// <param name="userId">
        /// User ID.
        /// </param>
        public void RemoveUser(int userId)
        {
            var user = this.context.Users.Find(userId);
            if (user != null)
            {
                this.context.Users.Remove(user);
            }
        }

        /// <summary>
        /// Validate user credentials.
        /// </summary>
        /// <param name="user">
        /// The user to validate.
        /// </param>
        /// <returns>
        /// Validation result. True if valid.
        /// </returns>
        public bool ValidateCredentials(User user)
        {
            var userLocal = this.context.Users.SingleOrDefault(u =>
                    (string.Compare(u.Email, user.Email, StringComparison.OrdinalIgnoreCase) == 0 &&
                    string.Compare(u.Password, user.Password, StringComparison.Ordinal) == 0));
            return userLocal != null;
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}