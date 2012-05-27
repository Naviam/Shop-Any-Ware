// --------------------------------------------------------------------------------------------------------------------
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
    using Orders;

    using TdService.Infrastructure.Domain;
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
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}