// --------------------------------------------------------------------------------------------------------------------
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
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                this.AddBrokenRule(UserBusinessRules.EmailRequired);
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.AddBrokenRule(UserBusinessRules.PasswordRequired);
            }
        }
    }
}