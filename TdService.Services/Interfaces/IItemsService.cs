// --------------------------------------------------------------------------------------------------------------------
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
        /// Edit Item in order
        /// </summary>
        /// <param name="request">edit order item request message</param>
        /// <returns>edit order item response message</returns>
        EditOrderItemResponse EditOrderItem(EditOrderItemRequest request);

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

        /// <summary>
        /// Get package items.
        /// </summary>
        /// <param name="request">
        /// The get package items request message.
        /// </param>
        /// <returns>
        /// The get package items response.
        /// </returns>
        List<GetPackageItemsResponse> GetPackageItems(GetPackageItemsRequest request);

        /// <summary>
        /// The remove item.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="RemoveItemResponse"/>.
        /// </returns>
        RemoveItemResponse RemoveItem(RemoveItemRequest request);
    }
}