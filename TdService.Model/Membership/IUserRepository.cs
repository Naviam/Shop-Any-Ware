// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   User repository contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using TdService.Model.Orders;

    /// <summary>
    /// User repository contract.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Attach order.
        /// </summary>
        /// <param name="email">
        /// The user email.
        /// </param>
        /// <param name="orderId">
        /// The order ID.
        /// </param>
        void AttachOrder(string email, int orderId);

        /// <summary>
        /// Get user by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user.
        /// </returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// Get user with orders by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user.
        /// </returns>
        User GetUserWithOrdersByEmail(string email);

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
        bool ValidateUser(string email, string password);

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// Created user.
        /// </returns>
        User CreateUser(User user);

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="user">
        /// The user to update.
        /// </param>
        void UpdateUser(User user);

        /// <summary>
        /// Remove user by user id.
        /// </summary>
        /// <param name="userId">
        /// User ID.
        /// </param>
        void RemoveUser(int userId);

        /// <summary>
        /// Validate user credentials.
        /// </summary>
        /// <param name="user">
        /// The user to validate.
        /// </param>
        /// <returns>
        /// Validation result. True if valid.
        /// </returns>
        bool ValidateCredentials(User user);

        /// <summary>
        /// Save changes to db.
        /// </summary>
        void SaveChanges();
    }
}