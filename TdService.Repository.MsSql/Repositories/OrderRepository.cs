﻿// -----------------------------------------------------------------------
// <copyright file="OrderRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System.Data;

    using TdService.Model.Orders;

    /// <summary>
    /// Order repository to work with orders in database.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopAnyWareSql context;

        public OrderRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get order details.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Order details.
        /// </returns>
        public Order GetOrderById(int orderId)
        {
            return this.context.Orders.Find(orderId);
        }

        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="order">
        /// The order to add.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order AddOrder(Order order)
        {
            return this.context.Orders.Add(order);
        }

        /// <summary>
        /// Update the order.
        /// </summary>
        /// <param name="order">
        /// The order to update.
        /// </param>
        public void UpdateOrder(Order order)
        {
            this.context.Entry(order).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove an order.
        /// </summary>
        /// <param name="orderId">
        /// The order ID to remove.
        /// </param>
        public void RemoveOrder(int orderId)
        {
            var order = this.context.Orders.Find(orderId);
            if (order != null)
            {
                this.context.Orders.Remove(order);
            }
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}