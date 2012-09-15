// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllOrdersResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get all orders response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    using System;

    /// <summary>
    /// The get all orders response.
    /// </summary>
    public class GetAllOrdersResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets order id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets retailer url.
        /// </summary>
        public string RetailerUrl { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets tracking number.
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets received date.
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// Gets or sets order status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the returned date.
        /// </summary>
        public DateTime? ReturnedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this order can be modified.
        /// </summary>
        public bool CanBeModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this order can be removed.
        /// </summary>
        public bool CanBeRemoved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this order can be requested for return.
        /// </summary>
        public bool CanBeRequestedForReturn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified { get; set; }
    }
}