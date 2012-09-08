﻿using System.Collections.Generic;

namespace TdService.UI.Web.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Item;
    using TdService.UI.Web.ViewModels;
    using TdService.UI.Web.ViewModels.Item;

    public static class ItemViewModelMapping
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
        /// Convert the list of get package items responses to the list of package item view models.
        /// </summary>
        /// <param name="packageItemsResponses">
        /// The package items responses.
        /// </param>
        /// <returns>
        /// The collection of package item view models.
        /// </returns>
        public static List<PackageItemViewModel> ConvertToPackageItemViewModelCollection(this List<GetPackageItemsResponse> packageItemsResponses)
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
    }
}
