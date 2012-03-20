// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This class describes user in the system
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Shoppers
{
    using System;
    using System.Collections.Generic;
    using Domain;
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
        /// Email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User's password
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
        public virtual IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets Balance.
        /// </summary>
        public virtual Balance Balance { get; set; }

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        public virtual IEnumerable<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets Parcels.
        /// </summary>
        public virtual IEnumerable<Parcel> Parcels { get; set; }

        /// <summary>
        /// Activate user.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public virtual void Activate()
        {
            throw new NotImplementedException();
        }
    }
}