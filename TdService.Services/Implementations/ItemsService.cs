// --------------------------------------------------------------------------------------------------------------------
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
    using TdService.Model.Common;
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
    public class ItemsService :ServiceBase, IItemsService
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
        public ItemsService(IItemsRepository itemsRepository, IPackageRepository packageRepository, ILogger logger):base(logger)
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
        /// Add item to package.
        /// </summary>
        /// <param name="request">
        /// The add item to package request message.
        /// </param>
        /// <returns>
        /// The add item to package response message.
        /// </returns>
        public AddItemToPackageResponse AddItemToPackage(AddItemToPackageRequest request)
        {
            var item = this.itemsRepository.GetItemById(request.ItemId);
            var package = this.packageRepository.GetPackageWithItemsById(request.PackageId);
            package.Items.Add(item);

            this.packageRepository.SaveChanges();

            return new AddItemToPackageResponse
                {
                    MessageType = MessageType.Warning,
                    Message = string.Format(CommonResources.OrderItemMovedToPackage, package.Name, package.Id)
                };
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
            catch(Exception ex)
            {
                this.logger.Error("Error while removing order item", ex);
                return new RemoveItemResponse { MessageType = MessageType.Error, Message = CommonResources.RemoveOrderItemErrorMessage };
            }
        }

        /// <summary>
        /// Edits order item's properties. 
        /// </summary>
        /// <param name="request">EditOrderItemRequest</param>
        /// <returns>EditOrderItemResponse</returns>
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
                    //opeartor has extended view with additional fields
                    item.Weight.Pounds = request.WeightPounds;
                    item.Dimensions.Girth = request.DimensionsGirth;
                    item.Dimensions.Height = request.DimensionsHeight;
                    item.Dimensions.Length = request.DimensionsLength;
                    item.Dimensions.Width = request.DimensionsWidth;
                }
                this.itemsRepository.UpdateItem(item);
                return new EditOrderItemResponse { MessageType = MessageType.Success, Message = CommonResources.OrderUpdateSuccessMessage };
            }
            catch (Exception ex)
            {
                this.logger.Error("Error while editing order item", ex);
                return new EditOrderItemResponse
                    { MessageType = MessageType.Error, Message = CommonResources.EditOrderItemErrorMessage };
            }
        }

        /// <summary>
        /// Adds item image
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>response</returns>
        public AddItemImageReponse AddItemImage(AddItemImageRequest request)
        {
            this.itemsRepository.AddImageToItem(
                request.ItemId, new ItemImage { Filename = request.ImageName, Url = request.ImageUrl });

            return new AddItemImageReponse { Url = request.ImageUrl, FileName = request.ImageName,ItemId = request.ItemId };
        }


        public MoveOrderItemsToExistingPackageResponse MoveOrderItemsToExistingPackage(MoveOrderItemsToExistingPackageRequest request)
        {
            var items = this.itemsRepository.GetOrderItems(request.OrderId);
            items.ForEach(i => itemsRepository.AttachItemToPackage(request.PackageId, i.Id));
            var result = items.ConvertToMoveOrderItemsToExistingPackageResponse();
            result.PackageId = request.PackageId;
            return result;
        }

        public MoveOrderItemsToNewPackageResponse MoveOrderItemsToNewPackage(MoveOrderItemsToNewPackageRequest request)
        {
            var package = this.packageRepository.AddPackage(
                request.IdentityToken, new Package { Name = request.PackageName, Status = PackageStatus.New, CreatedDate = DateTime.UtcNow, Dimensions = new Dimensions() });
            var items = this.itemsRepository.GetOrderItems(request.OrderId);
            items.ForEach(i => itemsRepository.AttachItemToPackage(package.Id, i.Id));
            var result = items.ConvertToMoveOrderItemsToNewPackageResponse();
            result.PackageId = package.Id;
            return result;
        }

        public MoveOrderItemsToOriginalOrderResponse MoveOrderItemsToOriginalOrder(MoveOrderItemsToOriginalOrderRequest request)
        {
            var items = this.itemsRepository.GetPackageItems(request.PackageId);
            items.ForEach(i => itemsRepository.DetachItemFromPackage(request.PackageId, i.Id));
            var result = items.ConvertToMoveOrderItemsToOriginalOrderResponse();
            result.PackageId = request.PackageId;
            return result;
        }
    }
}