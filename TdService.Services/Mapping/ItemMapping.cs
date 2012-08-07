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

    using TdService.Model.Items;
    using TdService.Services.Messaging.Item;
    using TdService.Services.ViewModels;
    using TdService.Services.ViewModels.Item;

    /// <summary>
    /// The item mapping.
    /// </summary>
    public static class ItemMapping
    {
        /// <summary>
        /// Convert the list of get order items responses to the list of order item view models.
        /// </summary>
        /// <param name="orderItemsResponses">
        /// The order items responses.
        /// </param>
        /// <returns>
        /// The collection of order item view models.
        /// </returns>
        public static List<OrderItemViewModel> ConvertToOrderItemViewModelCollection(this List<GetOrderItemsResponse> orderItemsResponses)
        {
            return Mapper.Map<List<GetOrderItemsResponse>, List<OrderItemViewModel>>(orderItemsResponses);
        }

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
        public static List<GetPackageItemsResponse> ConvertToGetPackageItemsResponse(this List<Item> items)
        {
            return Mapper.Map<List<Item>, List<GetPackageItemsResponse>>(items);
        }

        /// <summary>
        /// Convert the list of get package items responses to the list of package item view models.
        /// </summary>
        /// <param name="packageItemsResponses">
        /// The package items responses.
        /// </param>
        /// <returns>
        /// The collection of package item view models.
        /// </returns>
        public static List<PackageItemViewModel> ConvertToOrderItemViewModelCollection(this List<GetPackageItemsResponse> packageItemsResponses)
        {
            return Mapper.Map<List<GetPackageItemsResponse>, List<PackageItemViewModel>>(packageItemsResponses);
        }

        /// <summary>
        /// Convert add item to order response to order item view model.
        /// </summary>
        /// <param name="response">
        /// The add item to order response message.
        /// </param>
        /// <returns>
        /// The order item view model.
        /// </returns>
        public static OrderItemViewModel ConvertToOrderItemViewModel(this AddItemToOrderResponse response)
        {
            return Mapper.Map<AddItemToOrderResponse, OrderItemViewModel>(response);
        }

        /// <summary>
        /// Convert orders to get recent orders request.
        /// </summary>
        /// <param name="orderItemViewModel">
        /// The order Item View Model.
        /// </param>
        /// <returns>
        /// Collection of get recent orders requests.
        /// </returns>
        public static AddItemToOrderRequest ConvertToAddItemToOrderRequest(this OrderItemViewModel orderItemViewModel)
        {
            return Mapper.Map<OrderItemViewModel, AddItemToOrderRequest>(orderItemViewModel);
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
    }
}