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
    using TdService.Services.ViewModels.Order;

    /// <summary>
    /// The get recent orders response mapping.
    /// </summary>
    public static class OrderMapping
    {
        /// <summary>
        /// Convert profile view to profile domain object.
        /// </summary>
        /// <param name="getRecentOrdersResponseCollection">
        /// The response messages collection.
        /// </param>
        /// <returns>
        /// Order view model collection.
        /// </returns>
        public static List<OrderViewModel> ConvertToOrderViewModelCollection(this List<GetRecentOrdersResponse> getRecentOrdersResponseCollection)
        {
            return Mapper.Map<List<GetRecentOrdersResponse>, List<OrderViewModel>>(getRecentOrdersResponseCollection);
        }

        /// <summary>
        /// Convert orders to get recent orders response.
        /// </summary>
        /// <param name="orders">
        /// The orders.
        /// </param>
        /// <returns>
        /// Collection of get recent orders responses.
        /// </returns>
        public static List<GetRecentOrdersResponse> ConvertToRecentOrdersResponseCollection(this List<Order> orders)
        {
            return Mapper.Map<List<Order>, List<GetRecentOrdersResponse>>(orders);
        }

        /// <summary>
        /// Convert add order request to order view model.
        /// </summary>
        /// <param name="response">
        /// The add order response.
        /// </param>
        /// <returns>
        /// The order view model.
        /// </returns>
        public static OrderViewModel ConverToOrderViewModel(this AddOrderResponse response)
        {
            return Mapper.Map<AddOrderResponse, OrderViewModel>(response);
        }

        /// <summary>
        /// Convert order view model to add order request.
        /// </summary>
        /// <param name="model">
        /// The order view model.
        /// </param>
        /// <returns>
        /// The add order request.
        /// </returns>
        public static AddOrderRequest ConvertToAddOrderRequest(this OrderViewModel model)
        {
            return Mapper.Map<OrderViewModel, AddOrderRequest>(model);
        }

        /// <summary>
        /// Convert add order request to order.
        /// </summary>
        /// <param name="request">
        /// The add order request.
        /// </param>
        /// <returns>
        /// The order.
        /// </returns>
        public static Order ConvertToOrder(this AddOrderRequest request)
        {
            return Mapper.Map<AddOrderRequest, Order>(request);
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
    }
}