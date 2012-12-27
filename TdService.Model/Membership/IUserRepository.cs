// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   User repository contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
namespace TdService.Model.Membership
{
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
        /// Attach package to user.
        /// </summary>
        /// <param name="email">
        /// The user email.
        /// </param>
        /// <param name="packageId">
        /// The package id to attach.
        /// </param>
        void AttachPackage(string email, int packageId);

        /// <summary>
        /// Attach address to user.
        /// </summary>
        /// <param name="email">
        /// The user email.
        /// </param>
        /// <param name="addressId">
        /// The addresss id to attach.
        /// </param>
        void AttachAddress(string email, int addressId);

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
        /// The user with orders.
        /// </returns>
        User GetUserWithOrdersByEmail(string email);

        /// <summary>
        /// Get user with packages by email.
        /// </summary>
        /// <param name="email">
        /// The email address.
        /// </param>
        /// <returns>
        /// The user with packages.
        /// </returns>
        User GetUserWithPackagesByEmail(string email);

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
        /// Get users in role
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns></returns>
        List<User> GetUsersInRole(int roleId);

        /// <summary>
        /// Save changes to db.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Getsuser by Id
        /// </summary>
        /// <param name="Id">user ID</param>
        /// <returns>User</returns>
        User GetUserById(int id);
    }
}