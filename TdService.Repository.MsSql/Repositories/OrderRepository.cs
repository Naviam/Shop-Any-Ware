// -----------------------------------------------------------------------
// <copyright file="OrderRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Data;

    using TdService.Model.Common;
    using TdService.Model.Orders;

    /// <summary>
    /// Order repository to work with orders in database.
    /// </summary>
    public class OrderRepository : IOrderRepository, IDisposable
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
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
        /// Attach retailer.
        /// </summary>
        /// <param name="retailer">
        /// The retailer.
        /// </param>
        public void AttachRetailer(Retailer retailer)
        {
            this.context.Retailers.Attach(retailer);
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
            var order = new Order { Id = orderId };
            this.context.Orders.Attach(order);
            this.context.Orders.Remove(order);
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}