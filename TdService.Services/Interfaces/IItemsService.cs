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
        /// Edit Item in package
        /// </summary>
        /// <param name="request">edit package item request message</param>
        /// <returns>edit package item response message</returns>
        EditPackageItemResponse EditPackageItem(EditPackageItemRequest request);

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
        GetPackageItemsResponse GetPackageItems(GetPackageItemsRequest request);

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

        /// <summary>
        /// Adds image to item
        /// </summary>
        /// <param name="request">Uploaded image info</param>
        /// <returns>response</returns>
        AddItemImageReponse AddItemImage(AddItemImageRequest request);

        /// <summary>
        /// Moves order items to existing  package
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MoveOrderItemsToExistingPackageResponse MoveOrderItemsToExistingPackage(
            MoveOrderItemsToExistingPackageRequest request);

        /// <summary>
        /// Moves order items to new  package
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MoveOrderItemsToNewPackageResponse MoveOrderItemsToNewPackage(MoveOrderItemsToNewPackageRequest request);

        /// <summary>
        /// Moves package items to their original order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MoveOrderItemsToOriginalOrderResponse MoveOrderItemsToOriginalOrder(
            MoveOrderItemsToOriginalOrderRequest request);

        /// <summary>
        /// Move single item back to orig order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MoveItemBackToOriginalOrderResponse MoveOrderItemBackToOriginalOrder(MoveItemBackToOriginalOrderRequest request);

        /// <summary>
        /// Move single item to existing package
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MoveOrderItemToExistingPackageResponse MoveOrderItemsToExistingPackage(
            MoveOrderItemToExistingPackageRequest request);
    }
}