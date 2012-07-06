﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This class describes user in the system
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System.Collections.Generic;
    using Addresses;

    using Packages;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Balance;
    using TdService.Model.Orders;

    /// <summary>
    /// This class describes user in the system
    /// </summary>
    public class User : EntityBase<int>
    {
        /// <summary>
        /// Membership repository.
        /// </summary>
        private readonly IMembershipRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public User(IMembershipRepository repository)
        {
            this.repository = repository;
            this.Orders = new List<Order>();
            this.Packages = new List<Package>();
            this.Wallet = new Wallet();
            this.Profile = new Profile();
        }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets Profile.
        /// </summary>
        public Profile Profile { get; set; }

        /// <summary>
        /// Gets or sets DeliveryAddresses.
        /// </summary>
        public List<DeliveryAddress> DeliveryAddresses { get; set; }

        /// <summary>
        /// Gets or sets Orders.
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets Wallet.
        /// </summary>
        public Wallet Wallet { get; set; }

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets Packages.
        /// </summary>
        public List<Package> Packages { get; set; }

        /// <summary>
        /// Add new order to user.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        public void AddOrder(Order order)
        {
            this.Orders.Add(order);
        }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                this.AddBrokenRule(UserBusinessRules.EmailRequired);
            }
            else if (this.Email.Length > 256)
            {
                this.AddBrokenRule(UserBusinessRules.EmailLength);
            }
            else if (this.repository.GetUser(this.Email) != null)
            {
                this.AddBrokenRule(UserBusinessRules.EmailExists);
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.AddBrokenRule(UserBusinessRules.PasswordRequired);
            }
            else if (this.Password.Length > 64)
            {
                this.AddBrokenRule(UserBusinessRules.PasswordLength);
            }
            else if (this.Password.Length < 7)
            {
                this.AddBrokenRule(UserBusinessRules.PasswordMinLength);
            }
        }
    }
}