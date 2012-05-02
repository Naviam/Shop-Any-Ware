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
    using System;
    using System.Collections.Generic;
    using Addresses;
    using Model;
    using Orders;
    using Packages;

    /// <summary>
    /// This class describes user in the system
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets ActivationGuid.
        /// </summary>
        public string ActivationGuid { get; set; }

        /// <summary>
        /// Gets or sets Profile.
        /// </summary>
        public Profile Profile { get; set; }

        /// <summary>
        /// Gets or sets DeliveryAddresses.
        /// </summary>
        public IEnumerable<DeliveryAddress> DeliveryAddresses { get; set; }

        /// <summary>
        /// Gets or sets Orders.
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets Balance.
        /// </summary>
        public Balance Balance { get; set; }

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        public IEnumerable<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets Parcels.
        /// </summary>
        public IEnumerable<Package> Parcels { get; set; }

        /// <summary>
        /// Activate user.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// Not yet implemented.
        /// </exception>
        public virtual void Activate()
        {
            throw new NotImplementedException();
        }
    }
}