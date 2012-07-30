// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeUserRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The fake user repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Orders
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;

    /// <summary>
    /// The fake user repository.
    /// </summary>
    public class FakeUserRepository : IUserRepository
    {
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
            return null;
        }

        /// <summary>
        /// Attach order.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="orderId">
        /// The order ID.
        /// </param>
        public void AttachOrder(string email, int orderId)
        {
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
            if (email == "vhatalski@naviam.com")
            {
                return new User
                    {
                        Email = "vhatalski@naviam.com",
                        Id = 1,
                        Password = "ruinruin",
                        Profile = new Profile { FirstName = "Vitali", LastName = "Hatalski" },
                        Roles = new List<Role>(),
                        Packages = new List<Package>(),
                        Orders = null,
                        DeliveryAddresses = null
                    };
            }

            return null;
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
            var user = this.GetUserByEmail(email);
            if (user != null)
            {
                user.Orders = new List<Order>
                    {
                        new Order(OrderStatus.New)
                            {
                                CreatedDate = DateTime.UtcNow,
                                DisposedDate = null,
                                Id = 1,
                                OrderNumber = "12212",
                                ReceivedDate = null,
                                Retailer = new Retailer("amazon.com"),
                                ReturnedDate = null
                            },
                        new Order(OrderStatus.Received)
                            {
                                CreatedDate = DateTime.UtcNow,
                                DisposedDate = null,
                                Id = 2,
                                OrderNumber = "122122",
                                ReceivedDate = DateTime.UtcNow,
                                Retailer = new Retailer("apple.com"),
                                ReturnedDate = null
                            },
                        new Order(OrderStatus.ReturnRequested)
                            {
                                CreatedDate = DateTime.UtcNow,
                                DisposedDate = null,
                                Id = 3,
                                OrderNumber = "1221227776",
                                ReceivedDate = DateTime.UtcNow,
                                Retailer = new Retailer("apple.com"),
                                ReturnedDate = null
                            }
                    };
                return user;
            }

            return null;
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
            return true;
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
            return null;
        }

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="user">
        /// The user to update.
        /// </param>
        public void UpdateUser(User user)
        {
        }

        /// <summary>
        /// Remove user by user id.
        /// </summary>
        /// <param name="userId">
        /// User ID.
        /// </param>
        public void RemoveUser(int userId)
        {
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
            return false;
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public void SaveChanges()
        {
        }
    }
}