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
    using System;
    using System.Collections.Generic;

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
        /// The address id to attach.
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
        /// Validate user against DB.
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
        /// The get users in role.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// </returns>
        Tuple<List<User>, int> GetUsersInRole(int roleId, int skip, int take);

        /// <summary>
        /// The get all users.
        /// </summary>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// </returns>
        Tuple<List<User>, int> GetAllUsers(int skip, int take);

        /// <summary>
        /// Save changes to DB.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        User GetUserById(int id);

        /// <summary>
        /// The get user by password reset code.
        /// </summary>
        /// <param name="guid">
        /// The GUID.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        User GetUserByPwdResetCode(Guid guid);
    }
}