// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IItemsRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IProductRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Items
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the products repository.
    /// </summary>
    public interface IItemsRepository
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
        /// Get package items.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// Collection of package items.
        /// </returns>
        IEnumerable<Item> GetPackageItems(int packageId);

        /// <summary>
        /// Add item to an order.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The TdService.Model.Items.Item.
        /// </returns>
        Item AddItemToOrder(int orderId, Item item);

        /// <summary>
        /// Add item to package.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="item">
        /// The item to add.
        /// </param>
        /// <returns>
        /// The TdService.Model.Items.Item.
        /// </returns>
        Item AddItemToPackage(int packageId, Item item);

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
        /// Save changes to db.
        /// </summary>
        /// <returns>
        /// The result of operation.
        /// </returns>
        int SaveChanges();
    }
}