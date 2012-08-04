﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemsService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The ItemsService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Item;

    /// <summary>
    /// The Items Service interface.
    /// </summary>
    public interface IItemsService
    {
        /// <summary>
        /// Add item to order.
        /// </summary>
        /// <param name="request">
        /// The add item to order request message.
        /// </param>
        /// <returns>
        /// The add item to order response message.
        /// </returns>
        AddItemToOrderResponse AddItemToOrder(AddItemToOrderRequest request);

        /// <summary>
        /// Add item to package.
        /// </summary>
        /// <param name="request">
        /// The add item to package request message.
        /// </param>
        /// <returns>
        /// The add item to package response message.
        /// </returns>
        AddItemToPackageResponse AddItemToPackage(AddItemToPackageRequest request);

        /// <summary>
        /// Get order items.
        /// </summary>
        /// <param name="request">
        /// The get order items request message.
        /// </param>
        /// <returns>
        /// The get order items response message collection.
        /// </returns>
        List<GetOrderItemsResponse> GetOrderItems(GetOrderItemsRequest request);
    }
}