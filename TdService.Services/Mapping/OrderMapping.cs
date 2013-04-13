// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderMapping.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the OrderMapping type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Model.Orders;
    using TdService.Services.Messaging.Order;

    /// <summary>
    /// The get recent orders response mapping.
    /// </summary>
    public static class OrderMapping
    {
        /// <summary>
        /// Convert orders to get recent orders response.
        /// </summary>
        /// <param name="orders">
        /// The orders.
        /// </param>
        /// <returns>
        /// Collection of get recent orders responses.
        /// </returns>
        public static List<GetMyOrdersResponse> ConvertToMyOrdersResponseCollection(this List<Order> orders)
        {
            return Mapper.Map<List<Order>, List<GetMyOrdersResponse>>(orders);
        }

        /// <summary>
        /// The convert to get all orders response collection.
        /// </summary>
        /// <param name="orders">
        /// The orders.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Services.Messaging.Order.GetAllOrdersResponse].
        /// </returns>
        public static List<GetAllOrdersResponse> ConvertToGetAllOrdersResponseCollection(this List<Order> orders)
        {
            return Mapper.Map<List<Order>, List<GetAllOrdersResponse>>(orders);
        }

        /// <summary>
        /// Convert order to add order response.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The add order response.
        /// </returns>
        public static AddOrderResponse ConvertToAddOrderResponse(this Order order)
        {
            return Mapper.Map<Order, AddOrderResponse>(order);
        }

        /// <summary>
        /// The convert to update order response.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Order.UpdateOrderResponse.
        /// </returns>
        public static UpdateOrderResponse ConvertToUpdateOrderResponse(this Order order)
        {
            return Mapper.Map<Order, UpdateOrderResponse>(order);
        }

        /// <summary>
        /// The convert to remove order response.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Order.RemoveOrderResponse.
        /// </returns>
        public static RemoveOrderResponse ConvertToRemoveOrderResponse(this Order order)
        {
            return Mapper.Map<Order, RemoveOrderResponse>(order);
        }

        /// <summary>
        /// The convert to order received response.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The <see cref="OrderReceivedResponse"/>.
        /// </returns>
        public static OrderReceivedResponse ConvertToOrderReceivedResponse(this Order order)
        {
            return Mapper.Map<Order, OrderReceivedResponse>(order);
        }
    }
}