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
        /// Get item by Id.
        /// </summary>
        /// <param name="itemId">
        /// The item Id.
        /// </param>
        /// <returns>
        /// The item.
        /// </returns>
        Item GetItemById(int itemId);

        /// <summary>
        /// Get the list of order's products.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Collection of items.
        /// </returns>
        List<Item> GetOrderItems(int orderId);

        /// <summary>
        /// Get package items.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// Collection of package items.
        /// </returns>
        List<Item> GetPackageItems(int packageId);

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
        /// Attach item to package.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="itemId">
        /// The item id to attach.
        /// </param>
        void AttachItemToPackage(int packageId, int itemId);

        /// <summary>
        /// Detach item from package.
        /// </summary>
        /// <param name="packageId">
        /// The package Id.
        /// </param>
        /// <param name="itemId">
        /// The item Id.
        /// </param>
        void DetachItemFromPackage(int packageId, int itemId);

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
        /// <returns>
        /// The <see cref="Item"/>.
        /// </returns>
        Item RemoveItem(int itemId);

        /// <summary>
        /// The add image to item.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <param name="image">
        /// The image.
        /// </param>
        void AddImageToItem(int itemId, ItemImage image);
    }
}