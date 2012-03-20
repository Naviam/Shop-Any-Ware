// -----------------------------------------------------------------------
// <copyright file="Order.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;

    /// <summary>
    /// This class describes the order from online shops.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Shop.
        /// </summary>
        public Shop Shop { get; set; }

        /// <summary>
        /// Gets or sets OrderNumber.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets TrackingNumber.
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets ArrivalDate.
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Gets or sets Weight.
        /// </summary>
        public Weight Weight { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        public OrderStatus Status { get; set; }
    }
}