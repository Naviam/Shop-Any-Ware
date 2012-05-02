// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Package.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Package type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TdService.Model.Shipping;

namespace TdService.Model.Packages
{
    using System.Collections.Generic;
    using Addresses;
    using Model;
    using Orders;

    /// <summary>
    /// Parcel that user creates to send to home address.
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

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
        /// Gets or sets Services.
        /// </summary>
        public IEnumerable<Service> Services { get; set; }
    }
}