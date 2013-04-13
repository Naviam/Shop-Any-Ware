// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemViewModelMapping.cs" company="Naviam">
//   Vitali Hatalski. 2013
// </copyright>
// <summary>
//   Defines the ItemViewModelMapping type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Item;
    using TdService.UI.Web.ViewModels.Item;

    /// <summary>
    /// The item view model mapping.
    /// </summary>
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
        public static PackageItemsViewModel ConvertToPackageItemViewModelCollection(this GetPackageItemsResponse packageItemsResponses)
        {
            return Mapper.Map<GetPackageItemsResponse, PackageItemsViewModel>(packageItemsResponses);
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
        /// Convert edit order item response to order item view model.
        /// </summary>
        /// <param name="response">
        /// The edit order item response message.
        /// </param>
        /// <returns>
        /// The order item view model.
        /// </returns>
        public static OrderItemViewModel ConvertToOrderItemViewModel(this EditOrderItemResponse response)
        {
            return Mapper.Map<EditOrderItemResponse, OrderItemViewModel>(response);
        }

        /// <summary>
        /// The convert to package item view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageItemViewModel"/>.
        /// </returns>
        public static PackageItemViewModel ConvertToPackageItemViewModel(this EditPackageItemResponse response)
        {
            return Mapper.Map<EditPackageItemResponse, PackageItemViewModel>(response);
        }

        /// <summary>
        /// Convert orders to add item to order request.
        /// </summary>
        /// <param name="orderItemViewModel">
        /// The order Item View Model.
        /// </param>
        /// <returns>
        /// AddItemToOrderRequest instance.
        /// </returns>
        public static AddItemToOrderRequest ConvertToAddItemToOrderRequest(this OrderItemViewModel orderItemViewModel)
        {
            return Mapper.Map<OrderItemViewModel, AddItemToOrderRequest>(orderItemViewModel);
        }

        /// <summary>
        /// Convert orders to edit order item request.
        /// </summary>
        /// <param name="orderItemViewModel">
        /// The order Item View Model.
        /// </param>
        /// <returns>
        /// EditOrderItemRequest instance.
        /// </returns>
        public static EditOrderItemRequest ConvertToEditOrderItemRequest(this OrderItemViewModel orderItemViewModel)
        {
            return Mapper.Map<OrderItemViewModel, EditOrderItemRequest>(orderItemViewModel);
        }

        /// <summary>
        /// The convert to edit package item request.
        /// </summary>
        /// <param name="packageItemViewModel">
        /// The package item view model.
        /// </param>
        /// <returns>
        /// The <see cref="EditPackageItemRequest"/>.
        /// </returns>
        public static EditPackageItemRequest ConvertToEditPackageItemRequest(this PackageItemViewModel packageItemViewModel)
        {
            return Mapper.Map<PackageItemViewModel, EditPackageItemRequest>(packageItemViewModel);
        }

        /// <summary>
        /// The convert to remove item request.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="OrderItemViewModel"/>.
        /// </returns>
        public static OrderItemViewModel ConvertToOrderItemViewModel(this RemoveItemResponse response)
        {
            return Mapper.Map<RemoveItemResponse, OrderItemViewModel>(response);
        }

        /// <summary>
        /// The convert to item image view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="ItemImageViewModel"/>.
        /// </returns>
        public static ItemImageViewModel ConvertToItemImageViewModel(this AddItemImageResponse response)
        {
            return Mapper.Map<AddItemImageResponse, ItemImageViewModel>(response);
        }

        /// <summary>
        /// The convert to package item view model collection.
        /// </summary>
        /// <param name="moveOrderItemsToExistingPackageResponse">
        /// The move order items to existing package response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageItemsViewModel"/>.
        /// </returns>
        public static PackageItemsViewModel ConvertToPackageItemViewModelCollection(this MoveOrderItemsToExistingPackageResponse moveOrderItemsToExistingPackageResponse)
        {
            return Mapper.Map<MoveOrderItemsToExistingPackageResponse, PackageItemsViewModel>(moveOrderItemsToExistingPackageResponse);
        }

        /// <summary>
        /// The convert to package item view model collection.
        /// </summary>
        /// <param name="moveOrderItemsToNewPackageResponse">
        /// The move order items to new package response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageItemsViewModel"/>.
        /// </returns>
        public static PackageItemsViewModel ConvertToPackageItemViewModelCollection(this MoveOrderItemsToNewPackageResponse moveOrderItemsToNewPackageResponse)
        {
            return Mapper.Map<MoveOrderItemsToNewPackageResponse, PackageItemsViewModel>(moveOrderItemsToNewPackageResponse);
        }

        /// <summary>
        /// The convert to package item view model collection.
        /// </summary>
        /// <param name="moveOrderItemsToOriginalOrderResponse">
        /// The move order items to original order response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageItemsViewModel"/>.
        /// </returns>
        public static PackageItemsViewModel ConvertToPackageItemViewModelCollection(this MoveOrderItemsToOriginalOrderResponse moveOrderItemsToOriginalOrderResponse)
        {
            return Mapper.Map<MoveOrderItemsToOriginalOrderResponse, PackageItemsViewModel>(moveOrderItemsToOriginalOrderResponse);
        }

        /// <summary>
        /// The convert to package item view model.
        /// </summary>
        /// <param name="moveOrderItemToOriginalOrderResponse">
        /// The move order item to original order response.
        /// </param>
        /// <returns>
        /// The <see cref="MoveItemBackToOriginalOrderViewModel"/>.
        /// </returns>
        public static MoveItemBackToOriginalOrderViewModel ConvertToPackageItemViewModel(this MoveItemBackToOriginalOrderResponse moveOrderItemToOriginalOrderResponse)
        {
            return Mapper.Map<MoveItemBackToOriginalOrderResponse, MoveItemBackToOriginalOrderViewModel>(moveOrderItemToOriginalOrderResponse);
        }

        /// <summary>
        /// The convert to move order item to existing package view model.
        /// </summary>
        /// <param name="moveOrderItemToExistingOrderResponse">
        /// The move order item to existing order response.
        /// </param>
        /// <returns>
        /// The <see cref="MoveOrderItemToExistingPackageViewModel"/>.
        /// </returns>
        public static MoveOrderItemToExistingPackageViewModel ConvertToMoveOrderItemToExistingPackageViewModel(this MoveOrderItemToExistingPackageResponse moveOrderItemToExistingOrderResponse)
        {
            return Mapper.Map<MoveOrderItemToExistingPackageResponse, MoveOrderItemToExistingPackageViewModel>(moveOrderItemToExistingOrderResponse);
        }
    }
}
