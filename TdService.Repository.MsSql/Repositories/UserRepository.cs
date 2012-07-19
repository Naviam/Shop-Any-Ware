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

        public UserRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="userId">
        /// The user ID.
        /// </param>
        /// <returns>
        /// The user.
        /// </returns>
        public User GetUserById(int userId)
        {
            return this.context.Users.Find(userId);
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
            return this.context.Users.SingleOrDefault(u => u.Email == email);
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
            return this.context.Users.Include("Orders").SingleOrDefault(u => u.Email == email);
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
            return context.Users.Add(user);
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
            var userLocal = context.Users.SingleOrDefault(u =>
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