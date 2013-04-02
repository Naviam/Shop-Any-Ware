// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddOrderResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the AddOrderResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    using System;

    /// <summary>
    /// The add order response.
    /// </summary>
    public class AddOrderResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets order ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets retailer url.
        /// </summary>
        public string RetailerUrl { get; set; }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the tracking number.
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the received date.
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be received.
        /// </summary>
        public bool CanBeReceived { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether can items be added.
        /// </summary>
        public bool CanItemsBeAdded { get; set; }
    }
}