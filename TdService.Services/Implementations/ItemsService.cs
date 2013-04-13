﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The items service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Items;
    using TdService.Model.Packages;
    using TdService.Resources;
    using TdService.Services.Base;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Item;

    /// <summary>
    /// The items service.
    /// </summary>
    public class ItemsService : ServiceBase, IItemsService
    {
        /// <summary>
        /// The items repository.
        /// </summary>
        private readonly IItemsRepository itemsRepository;

        /// <summary>
        /// The package repository.
        /// </summary>
        private readonly IPackageRepository packageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsService"/> class.
        /// </summary>
        /// <param name="itemsRepository">
        /// The items repository.
        /// </param>
        /// <param name="packageRepository">
        /// The package repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ItemsService(IItemsRepository itemsRepository, IPackageRepository packageRepository, ILogger logger)
            : base(logger)
        {
            this.itemsRepository = itemsRepository;
            this.packageRepository = packageRepository;
        }

        /// <summary>
        /// Add item to order.
        /// </summary>
        /// <param name="request">
        /// The add item to order request message.
        /// </param>
        /// <returns>
        /// The add item to order response message.
        /// </returns>
        public AddItemToOrderResponse AddItemToOrder(AddItemToOrderRequest request)
        {
            var item = request.ConvertToItem();
            
            if (item.GetBrokenRules().Any())
            {
                var sb = new StringBuilder();
                foreach (var rule in item.GetBrokenRules())
                {
                    sb.Append(rule.Property);
                    sb.Append(": ");
                    sb.Append(rule.ErrorCode);
                    sb.Append(" ");
                }

                return new AddItemToOrderResponse
                    {
                        Message = sb.ToString(),
                        MessageType = MessageType.Error
                    };
            }

            var addedItem = this.itemsRepository.AddItemToOrder(request.OrderId, item);
            var response = addedItem.ConvertToAddItemToOrderResponse();
            response.OrderId = request.OrderId;
            response.MessageType = MessageType.Success;
            response.Message = CommonResources.OrderItemSuccessfullyAdded;
            return response;
        }

        /// <summary>
        /// Get order items.
        /// </summary>
        /// <param name="request">
        /// The get order items request message.
        /// </param>
        /// <returns>
        /// The get order items response message.
        /// </returns>
        public List<GetOrderItemsResponse> GetOrderItems(GetOrderItemsRequest request)
        {
            var orderItems = this.itemsRepository.GetOrderItems(request.OrderId).ToList();
            return orderItems.ConvertToGetOrderItemsResponse();
        }

        /// <summary>
        /// Get package items.
        /// </summary>
        /// <param name="request">
        /// The get package items request message.
        /// </param>
        /// <returns>
        /// The collection of get package items responses.
        /// </returns>
        public GetPackageItemsResponse GetPackageItems(GetPackageItemsRequest request)
        {
            var packageItems = this.itemsRepository.GetPackageItems(request.PackageId);
            return packageItems.ConvertToGetPackageItemsResponse();
        }

        /// <summary>
        /// The remove item.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="RemoveItemResponse"/>.
        /// </returns>
        public RemoveItemResponse RemoveItem(RemoveItemRequest request)
        {
            try
            {
                var removedItem = this.itemsRepository.RemoveItem(request.Id);
                var response = removedItem.ConvertToRemoveItemResponse();
                response.Message = CommonResources.OrderItemRemovedMessage;
                response.MessageType = MessageType.Success;    
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Error("Error while removing order item", ex);
                return new RemoveItemResponse { MessageType = MessageType.Error, Message = CommonResources.RemoveOrderItemErrorMessage };
            }
        }

        /// <summary>
        /// The edit order item.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="EditOrderItemResponse"/>.
        /// </returns>
        public EditOrderItemResponse EditOrderItem(EditOrderItemRequest request)
        {
            try
            {
                var item = this.itemsRepository.GetItemById(request.Id);
                item.Price = request.Price;
                item.Quantity = request.Quantity;
                item.Name = request.Name;
                if (request.OperatorMode)
                {
                    // operator has extended view with additional fields
                    item.Weight.Pounds = request.WeightPounds;
                    item.Dimensions.Girth = request.DimensionsGirth;
                    item.Dimensions.Height = request.DimensionsHeight;
                    item.Dimensions.Length = request.DimensionsLength;
                    item.Dimensions.Width = request.DimensionsWidth;
                }

                this.itemsRepository.UpdateItem(item);
                var response = item.ConvertToEditOrderItemResponse();
                response.MessageType = MessageType.Success;
                response.Message = CommonResources.OrderItemUpdateSuccessMessage;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Error("Error while editing order item", ex);
                return new EditOrderItemResponse
                           {
                               MessageType = MessageType.Error,
                               Message = CommonResources.EditOrderItemErrorMessage
                           };
            }
        }

        /// <summary>
        /// The edit package item.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="EditPackageItemResponse"/>.
        /// </returns>
        public EditPackageItemResponse EditPackageItem(EditPackageItemRequest request)
        {
            try
            {
                var item = this.itemsRepository.GetItemById(request.Id);
                item.Price = request.Price;
                item.Quantity = request.Quantity;
                item.Name = request.Name;
                if (request.OperatorMode)
                {
                    // opeartor has extended view with additional fields
                    item.Weight.Pounds = request.WeightPounds;
                    item.Dimensions.Girth = request.DimensionsGirth;
                    item.Dimensions.Height = request.DimensionsHeight;
                    item.Dimensions.Length = request.DimensionsLength;
                    item.Dimensions.Width = request.DimensionsWidth;
                }

                this.itemsRepository.UpdateItem(item);
                var response = item.ConvertToEditPackageItemResponse();
                response.MessageType = MessageType.Success; 
                response.Message = CommonResources.PackageItemUpdateSuccessMessage;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Error("Error while editing package item", ex);
                return new EditPackageItemResponse { MessageType = MessageType.Error, Message = CommonResources.EditPackageItemErrorMessage };
            }
        }

        /// <summary>
        /// The add item image.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="AddItemImageResponse"/>.
        /// </returns>
        public AddItemImageResponse AddItemImage(AddItemImageRequest request)
        {
            this.itemsRepository.AddImageToItem(
                request.ItemId, new ItemImage { Filename = request.ImageName, Url = request.ImageUrl });

            return new AddItemImageResponse { Url = request.ImageUrl, FileName = request.ImageName, ItemId = request.ItemId };
        }

        /// <summary>
        /// The move order items to existing package.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="MoveOrderItemsToExistingPackageResponse"/>.
        /// </returns>
        public MoveOrderItemsToExistingPackageResponse MoveOrderItemsToExistingPackage(MoveOrderItemsToExistingPackageRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageWithItemsById(request.PackageId);
                var items = this.itemsRepository.GetOrderItems(request.OrderId);
                items.ForEach(i => this.itemsRepository.AttachItemToPackage(request.PackageId, i.Id));
                var result = items.ConvertToMoveOrderItemsToExistingPackageResponse();
                result.PackageId = request.PackageId;
                result.OrderId = request.OrderId;
                result.MessageType = MessageType.Success;
                result.Message = string.Format(CommonResources.OrderItemsSuccessfullyMoved, package.Name, package.Id);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger.Error("Error while moving order items to existing package", ex);
                return new MoveOrderItemsToExistingPackageResponse { MessageType = MessageType.Error, Message = CommonResources.MoveOrderItemsToExistingPackageError };
            }
        }

        /// <summary>
        /// The move order items to original order.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="MoveOrderItemsToOriginalOrderResponse"/>.
        /// </returns>
        public MoveOrderItemsToOriginalOrderResponse MoveOrderItemsToOriginalOrder(MoveOrderItemsToOriginalOrderRequest request)
        {
            try
            {
                var items = this.itemsRepository.GetPackageItems(request.PackageId);
                items.ForEach(i => this.itemsRepository.DetachItemFromPackage(request.PackageId, i.Id));
                var result = items.ConvertToMoveOrderItemsToOriginalOrderResponse();
                result.PackageId = request.PackageId;
                result.MessageType = MessageType.Success;
                result.Message = string.Format(
                    CommonResources.PackageItemsSuccessfullyMovedBackToOriginalOrder, items.First().OrderId);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger.Error("Error while moving order items back to original order", ex);
                return new MoveOrderItemsToOriginalOrderResponse { MessageType = MessageType.Error, Message = CommonResources.MoveOrderItemsToOriginalOrderError };
            }
        }

        /// <summary>
        /// The move order item back to original order.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="MoveItemBackToOriginalOrderResponse"/>.
        /// </returns>
        public MoveItemBackToOriginalOrderResponse MoveOrderItemBackToOriginalOrder(MoveItemBackToOriginalOrderRequest request)
        {
            try
            {
                var item = this.itemsRepository.GetItemById(request.ItemId);
                if (item.PackageId != null)
                {
                    var packageId = item.PackageId.Value;
                    this.itemsRepository.DetachItemFromPackage(item.PackageId.Value, item.Id);
                    var response = item.ConvertToMoveOrderItemToOriginalOrderResponse();
                    response.OrderId = item.OrderId;
                    response.PackageId = packageId;
                    response.MessageType = MessageType.Success;
                    response.Message = string.Format(CommonResources.OrderItemMovedToOriginalOrder, item.OrderId);
                    return response;
                }
            }
            catch (Exception ex)
            {
                this.Logger.Error("Error while moving order item back to original order", ex);
                return new MoveItemBackToOriginalOrderResponse { MessageType = MessageType.Error, Message = CommonResources.MoveOrderItemToOriginalOrderError };
            }

            return null;
        }

        /// <summary>
        /// The move order items to existing package.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="MoveOrderItemToExistingPackageResponse"/>.
        /// </returns>
        public MoveOrderItemToExistingPackageResponse MoveOrderItemsToExistingPackage(MoveOrderItemToExistingPackageRequest request)
        {
            try
            {
                this.itemsRepository.AttachItemToPackage(request.PackageId, request.ItemId);
                var item = this.itemsRepository.GetItemById(request.ItemId);
                var result = item.ConvertToMoveOrderItemToExistingPackageResponse();
                result.PackageId = request.PackageId;
                result.OrderId = item.OrderId;
                result.MessageType = MessageType.Success;
                result.Message = string.Format(CommonResources.OrderItemSuccessfullyMoved, request.PackageId);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger.Error("Error while moving order item to existing package", ex);
                return new MoveOrderItemToExistingPackageResponse { MessageType = MessageType.Error, Message = CommonResources.MoveOrderItemToExistingPackageError };
            }
        }
    }
}