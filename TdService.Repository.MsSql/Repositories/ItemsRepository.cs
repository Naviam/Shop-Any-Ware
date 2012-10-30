﻿// --------------------------------------------------------------------------------------------------------------------
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

    using TdService.Model.Items;

    /// <summary>
    /// The items repository.
    /// </summary>
    public class ItemsRepository : IItemsRepository
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
        public Item GetItemById(int itemId)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Items.Find(itemId);
            }
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
            using (var context = new ShopAnyWareSql())
            {
                var order = context.Orders.Include("Items").SingleOrDefault(o => o.Id == orderId);
                return order != null ? order.Items : null;
            }
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
            using (var context = new ShopAnyWareSql())
            {
                var package = context.Packages.Include("Items").SingleOrDefault(p => p.Id == packageId);
                return package != null ? package.Items : null;
            }
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
            using (var context = new ShopAnyWareSql())
            {
                var newItem = context.Items.Add(item);
                var order = context.Orders.Include("Items").SingleOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    if (order.Items == null)
                    {
                        order.Items = new List<Item>();
                    }

                    order.Items.Add(newItem);
                    context.SaveChanges();
                }

                return newItem;
            }
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
            using (var context = new ShopAnyWareSql())
            {
                var item = context.Items.Find(itemId);
                var package = context.Packages.Include("Items").SingleOrDefault(p => p.Id == packageId);
                if (package != null)
                {
                    package.Items.Add(item);
                    context.SaveChanges();
                }
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
            using (var context = new ShopAnyWareSql())
            {
                var package = context.Packages.Include("Items").SingleOrDefault(p => p.Id == packageId);
                if (package != null)
                {
                    var itemToDetach = package.Items.SingleOrDefault(i => i.Id == itemId);

                    if (itemToDetach != null)
                    {
                        package.Items.Remove(itemToDetach);
                        context.SaveChanges();
                    }
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
            using (var context = new ShopAnyWareSql())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Remove item completely.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        public void RemoveItem(int itemId)
        {
            using (var context = new ShopAnyWareSql())
            {
                var item = context.Items.Find(itemId);
                context.Items.Remove(item);
                context.SaveChanges();
            }
        }
    }
}