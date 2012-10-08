// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The items repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using TdService.Model.Common;
    using TdService.Model.Items;

    /// <summary>
    /// The items repository.
    /// </summary>
    public class ItemsRepository : IItemsRepository
    {
        /// <summary>
        /// Shop any ware db context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ItemsRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get item by Id.
        /// </summary>
        /// <param name="itemId">
        /// The item Id.
        /// </param>
        /// <returns>
        /// The item.
        /// </returns>
        public Item GetItemById(int itemId)
        {
            return this.context.Items.Find(itemId);
        }

        /// <summary>
        /// Get the list of order's products.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Collection of items.
        /// </returns>
        public List<Item> GetOrderItems(int orderId)
        {
            var order = this.context.Orders.Include("Items").SingleOrDefault(o => o.Id == orderId);
            return order != null ? order.Items : null;
        }

        /// <summary>
        /// Get package items.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// Collection of package items.
        /// </returns>
        public List<Item> GetPackageItems(int packageId)
        {
            var package = this.context.Packages.Include("Items").SingleOrDefault(p => p.Id == packageId);
            return package != null ? package.Items : null;
        }

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
        public Item AddItemToOrder(int orderId, Item item)
        {
            var newItem = this.context.Items.Add(item);
            var order = this.context.Orders.Include("Items").SingleOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                if (order.Items == null)
                {
                    order.Items = new List<Item>();
                }

                order.Items.Add(newItem);
            }

            return newItem;
        }

        /// <summary>
        /// Attach item to package.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="itemId">
        /// The item id to attach.
        /// </param>
        public void AttachItemToPackage(int packageId, int itemId)
        {
            var item = this.context.Items.Find(itemId);
            var package = this.context.Packages.Include("Items").SingleOrDefault(p => p.Id == packageId);
            if (package != null)
            {
                package.Items.Add(item);
            }
        }

        /// <summary>
        /// Detach item from package.
        /// </summary>
        /// <param name="packageId">
        /// The package Id.
        /// </param>
        /// <param name="itemId">
        /// The item Id.
        /// </param>
        public void DetachItemFromPackage(int packageId, int itemId)
        {
            var package = this.context.Packages.Include("Items").SingleOrDefault(p => p.Id == packageId);
            if (package != null)
            {
                var itemToDetach = package.Items.SingleOrDefault(i => i.Id == itemId);

                if (itemToDetach != null)
                {
                    package.Items.Remove(itemToDetach);
                }
            }
        }

        /// <summary>
        /// Update item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void UpdateItem(Item item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove item completely.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        public void RemoveItem(int itemId)
        {
            var item = this.context.Items.Find(itemId);
            this.context.Items.Remove(item);
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        /// <returns>
        /// The result of operation.
        /// </returns>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}