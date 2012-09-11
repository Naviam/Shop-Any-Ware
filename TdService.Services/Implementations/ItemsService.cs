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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TdService.Model.Items;
    using TdService.Model.Packages;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Item;

    /// <summary>
    /// The items service.
    /// </summary>
    public class ItemsService : IItemsService
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
        public ItemsService(IItemsRepository itemsRepository, IPackageRepository packageRepository)
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
            this.itemsRepository.SaveChanges();
            var response = addedItem.ConvertToAddItemToOrderResponse();
            response.MessageType = MessageType.Warning;
            response.Message = "The item has been added successfully.";
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
                    Message = string.Format("The item has been moved to package {0}, id: {1}", package.Name, package.Id)
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
        public List<GetPackageItemsResponse> GetPackageItems(GetPackageItemsRequest request)
        {
            var packageItems = this.itemsRepository.GetPackageItems(request.PackageId);
            return packageItems.ConvertToGetPackageItemsResponse();
        }
    }
}