// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderLineItem.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the OrderLineItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;
    using Items;

    /// <summary>
    /// The order item.
    /// </summary>
    public class OrderLineItem
    {
        /// <summary>
        /// Gets or sets Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Item.
        /// </summary>
        public Item Item { get; set; }
    }
}