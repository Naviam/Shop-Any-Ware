// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IUserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for user repository.
    /// </summary>
    public interface IUserRepository
    {
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
        /// Update user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        void UpdateUser(User user);

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
        /// <param name="user">
        /// The user.
        /// </param>
        void RemoveUser(User user);
    }
}