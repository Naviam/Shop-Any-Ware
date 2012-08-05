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
    using TdService.Model.Items;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
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
        /// Initializes a new instance of the <see cref="ItemsService"/> class.
        /// </summary>
        /// <param name="itemsRepository">
        /// The items repository.
        /// </param>
        public ItemsService(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
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
            // TODO: validate item
            var addedItem = this.itemsRepository.AddItemToOrder(request.OrderId, item);
            this.itemsRepository.SaveChanges();
            return addedItem.ConvertToAddItemToOrderResponse();
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
            return null;
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
    }
}