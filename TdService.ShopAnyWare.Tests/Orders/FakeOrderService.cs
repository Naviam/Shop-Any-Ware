namespace TdService.ShopAnyWare.Tests.Orders
{
    using System.Collections.Generic;

    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Order;

    public class FakeOrderService : IOrderService
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
        public IEnumerable<GetRecentOrdersResponse> GetRecent(GetRecentOrdersRequest request)
        {
            yield break;
        }
    }
}
