// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOrderService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The OrderService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Order;

    /// <summary>
    /// The OrderService interface.
    /// </summary>
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
        List<GetRecentOrdersResponse> GetRecent(GetRecentOrdersRequest request);

        /// <summary>
        /// The get history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of response messages.
        /// </returns>
        List<GetRecentOrdersResponse> GetHistory(GetRecentOrdersRequest request);

        /// <summary>
        /// Add new order.
        /// </summary>
        /// <param name="request">
        /// The add new order request.
        /// </param>
        /// <returns>
        /// The add order response.
        /// </returns>
        AddOrderResponse AddOrder(AddOrderRequest request);

        /// <summary>
        /// Remove order in new status.
        /// </summary>
        /// <param name="request">
        /// The remove order request.
        /// </param>
        /// <returns>
        /// The remove order response.
        /// </returns>
        RemoveOrderResponse RemoveOrder(RemoveOrderRequest request);

        /// <summary>
        /// The update order.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Order.UpdateOrderResponse.
        /// </returns>
        UpdateOrderResponse UpdateOrder(UpdateOrderRequest request);
    }
}
