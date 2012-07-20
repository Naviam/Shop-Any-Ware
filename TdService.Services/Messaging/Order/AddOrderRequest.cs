// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddOrderRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The add order request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    using System;

    /// <summary>
    /// The add order request.
    /// </summary>
    public class AddOrderRequest : RequestBase
    {
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
    }
}