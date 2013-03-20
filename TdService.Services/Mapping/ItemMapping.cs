// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemMapping.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The item mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Services.Messaging.Item;

    /// <summary>
    /// The item mapping.
    /// </summary>
    public static class ItemMapping
    {
        /// <summary>
        /// Convert items to get order items responses.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// Collection of get order items responses.
        /// </returns>
        public static List<GetOrderItemsResponse> ConvertToGetOrderItemsResponse(this List<Item> items)
        {
            return Mapper.Map<List<Item>, List<GetOrderItemsResponse>>(items);
        }

        /// <summary>
        /// Convert items to get package items responses.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <returns>
        /// Collection of get package items responses.
        /// </returns>
        public static GetPackageItemsResponse ConvertToGetPackageItemsResponse(this List<Item> items)
        {
            return Mapper.Map<List<Item>, GetPackageItemsResponse>(items);
        }

        /// <summary>
        /// Convert add item to order request to item model.
        /// </summary>
        /// <param name="addItemToOrderRequest">
        /// The add item to order request message.
        /// </param>
        /// <returns>
        /// The item.
        /// </returns>
        public static Item ConvertToItem(this AddItemToOrderRequest addItemToOrderRequest)
        {
            return Mapper.Map<AddItemToOrderRequest, Item>(addItemToOrderRequest);
        }

        /// <summary>
        /// Convert the item model to add item to order response message.
        /// </summary>
        /// <param name="item">
        /// The item model.
        /// </param>
        /// <returns>
        /// The add item to order response message.
        /// </returns>
        public static AddItemToOrderResponse ConvertToAddItemToOrderResponse(this Item item)
        {
            return Mapper.Map<Item, AddItemToOrderResponse>(item);
        }

        /// <summary>
        /// The convert to remove item response.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="RemoveItemResponse"/>.
        /// </returns>
        public static RemoveItemResponse ConvertToRemoveItemResponse(this Item item)
        {
            return Mapper.Map<Item, RemoveItemResponse>(item);
        }

        public static MoveOrderItemsToExistingPackageResponse ConvertToMoveOrderItemsToExistingPackageResponse(this List<Item> itemList)
        {
            return Mapper.Map<List<Item>, MoveOrderItemsToExistingPackageResponse>(itemList);
        }

        public static MoveOrderItemsToNewPackageResponse ConvertToMoveOrderItemsToNewPackageResponse(this List<Item> itemList)
        {
            return Mapper.Map<List<Item>, MoveOrderItemsToNewPackageResponse>(itemList);
        }

        public static MoveOrderItemsToOriginalOrderResponse ConvertToMoveOrderItemsToOriginalOrderResponse(this List<Item> itemList)
        {
            return Mapper.Map<List<Item>, MoveOrderItemsToOriginalOrderResponse>(itemList);
        }
    }
}