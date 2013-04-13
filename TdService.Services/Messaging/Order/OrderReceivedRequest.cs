// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderReceivedRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The order received request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    /// <summary>
    /// The order received request.
    /// </summary>
    public class OrderReceivedRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }
    }
}
