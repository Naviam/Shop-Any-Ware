// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeOrderRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the FakeOrderRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Orders
{
    using System.Collections.Generic;

    using TdService.Model.Orders;

    /// <summary>
    /// The fake order repository.
    /// </summary>
    public class FakeOrderRepository : IOrderRepository
    {
        /// <summary>
        /// The orders.
        /// </summary>
        private readonly List<Order> orders;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeOrderRepository"/> class.
        /// </summary>
        /// <param name="orders">
        /// The orders.
        /// </param>
        public FakeOrderRepository(List<Order> orders)
        {
            this.orders = orders;
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
            this.orders.Add(order);
            order.Id = this.orders.IndexOf(order);
            return order;
        }

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="orderId">
        /// The order ID to remove.
        /// </param>
        public void RemoveOrder(int orderId)
        {
            var order = this.orders.Find(o => o.Id == orderId);
            this.orders.Remove(order);
        }

        /// <summary>
        /// Update order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        public void UpdateOrder(Order order)
        {
            var orderToUpdate = this.orders.Find(order1 => order1.Id == order.Id);
            this.orders.RemoveAt(orderToUpdate.Id);
            this.orders.Insert(orderToUpdate.Id, order);
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
            return this.orders.Find(order1 => order1.Id == orderId);
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public void SaveChanges()
        {
        }
    }
}