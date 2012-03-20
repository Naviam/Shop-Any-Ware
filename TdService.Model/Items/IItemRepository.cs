// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IProductRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Items
{
    using System.Collections.Generic;
    using Infrastructure.Domain;

    /// <summary>
    /// Interface for the products repository.
    /// </summary>
    public interface IItemRepository : IRepository<Item, int>
    {
        /// <summary>
        /// Get the list of order's products.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Collection of items.
        /// </returns>
        IEnumerable<Item> GetOrderItems(int orderId);

        /// <summary>
        /// Add item to an order.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        void AddItemToOrder(int orderId, Item item);

        /// <summary>
        /// Update item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void UpdateItem(Item item);

        /// <summary>
        /// Remove item completely.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        void RemoveItem(int itemId);

        /// <summary>
        /// Request return of a product back to the shop.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        void RequestItemReturn(int itemId);
    }
}