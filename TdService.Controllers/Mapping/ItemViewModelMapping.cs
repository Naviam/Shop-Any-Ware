using System.Collections.Generic;

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
        /// The edit order itme response message.
        /// </param>
        /// <returns>
        /// The order item view model.
        /// </returns>
        public static OrderItemViewModel ConvertToOrderItemViewModel(this EditOrderItemResponse response)
        {
            return Mapper.Map<EditOrderItemResponse, OrderItemViewModel>(response);
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

        public static ItemImageViewModel ConvertToItemImageViewModel(this  AddItemImageReponse  response)
        {
            return Mapper.Map<AddItemImageReponse, ItemImageViewModel>(response);
        }


        public static PackageItemsViewModel ConvertToPackageItemViewModelCollection(this MoveOrderItemsToExistingPackageResponse moveOrderItemsToExistingPackageResponse)
        {
            return Mapper.Map<MoveOrderItemsToExistingPackageResponse, PackageItemsViewModel>(moveOrderItemsToExistingPackageResponse);
        }

        public static PackageItemsViewModel ConvertToPackageItemViewModelCollection(this MoveOrderItemsToNewPackageResponse moveOrderItemsToNewPackageResponse)
        {
            return Mapper.Map<MoveOrderItemsToNewPackageResponse, PackageItemsViewModel>(moveOrderItemsToNewPackageResponse);
        }

        public static PackageItemsViewModel ConvertToPackageItemViewModelCollection(this MoveOrderItemsToOriginalOrderResponse moveOrderItemsToOriginalOrderResponse)
        {
            return Mapper.Map<MoveOrderItemsToOriginalOrderResponse, PackageItemsViewModel>(moveOrderItemsToOriginalOrderResponse);
        }
    }
}
