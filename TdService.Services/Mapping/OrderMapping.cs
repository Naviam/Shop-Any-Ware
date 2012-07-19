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
    }
}