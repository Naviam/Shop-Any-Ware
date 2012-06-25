﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Package.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Package type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages
{
    using System;
    using System.Collections.Generic;
    using Addresses;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Orders;
    using TdService.Model.Shipping;

    /// <summary>
    /// Parcel that user creates to send to home address.
    /// </summary>
    public class Package : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        public PackageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets Dispatched Date.
        /// </summary>
        public DateTime DispatchedDate { get; set; }

        /// <summary>
        /// Gets or sets Delivered Date.
        /// </summary>
        public DateTime DeliveredDate { get; set; }

        /// <summary>
        /// Gets or sets Delivery Address.
        /// </summary>
        public DeliveryAddress DeliveryAddress { get; set; }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets Orders.
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets DispatchMethod.
        /// </summary>
        public DispatchMethod DispatchMethod { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.AddBrokenRule(PackageBusinessRules.NameRequired);
            }
            else if (this.Name.Length > 64)
            {
                this.AddBrokenRule(PackageBusinessRules.NameLength);
            }
        }
    }
}