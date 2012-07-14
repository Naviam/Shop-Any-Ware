namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Order;

    public interface IOrderService
    {
        /// <summary>
        /// Get recent orders (new or received within 30 days)
        /// </summary>
        /// <param name="request">
        /// The request message.
        /// </param>
        /// <returns>
        /// Collection of response messages.
        /// </returns>
        IEnumerable<GetRecentOrdersResponse> GetRecent(GetRecentOrdersRequest request);
    }
}
