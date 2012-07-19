// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetRecentOrdersResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Get recent orders response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    using System;

    /// <summary>
    /// Get recent orders response.
    /// </summary>
    public class GetRecentOrdersResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets order id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets retailer name.
        /// </summary>
        public string RetailerName { get; set; }

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
    }
}