// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IUserRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TdService.Model.Membership;

namespace TdService.Model.Membership
{
    /// <summary>
    /// Interface for user repository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get user by name.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// User object.
        /// </returns>
        User GetUser(string username);

        /// <summary>
        /// Validate user credentials.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Boolean value that indicates the result of validation.
        /// </returns>
        bool ValidateUser(string username, string password);

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
        /// Get users.
        /// </summary>
        /// <param name="sortDirection">
        /// The sort direction.
        /// </param>
        /// <param name="sortExpression">
        /// The sort expression.
        /// </param>
        /// <param name="filterExpression">
        /// The filter expression.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// Collection of users.
        /// </returns>
        IEnumerable<User> GetUsers(object sortDirection, string sortExpression, string filterExpression, int pageSize = 20);

        /// <summary>
        /// Remove user.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        void RemoveUser(string username);
    }
}