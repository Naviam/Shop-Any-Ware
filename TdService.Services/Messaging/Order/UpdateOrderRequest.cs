// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateOrderRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The update order request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    /// <summary>
    /// The update order request.
    /// </summary>
    public class UpdateOrderRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the retailer url.
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
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}