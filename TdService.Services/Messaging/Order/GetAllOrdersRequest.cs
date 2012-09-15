// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllOrdersRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get all orders request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    /// <summary>
    /// The get all orders request.
    /// </summary>
    public class GetAllOrdersRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the skip.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Gets or sets the take.
        /// </summary>
        public int Take { get; set; }
    }
}
