// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parcel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Parcel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages
{
    using System.Collections.Generic;
    using Domain;
    using Orders;

    /// <summary>
    /// Parcel that user creates to send to home address.
    /// </summary>
    public class Parcel
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
        public virtual IEnumerable<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets DispatchMethod.
        /// </summary>
        public virtual DispatchMethod DispatchMethod { get; set; }

        /// <summary>
        /// Gets or sets Services.
        /// </summary>
        public virtual IEnumerable<Service> Services { get; set; }
    }
}