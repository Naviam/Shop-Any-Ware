// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOrderItemsRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get order items request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    using TdService.Services.Messaging;

    /// <summary>
    /// The get order items request.
    /// </summary>
    public class GetOrderItemsRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }
    }
}