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

    using TdService.Model.Common;
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
        /// Attach retailer.
        /// </summary>
        /// <param name="retailer">
        /// The retailer.
        /// </param>
        public void AttachRetailer(Retailer retailer)
        {
        }

        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="order">
        /// The order to add.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order AddOrder(string email, Order order)
        {
            this.orders.Add(order);
            order.Id = this.orders.IndexOf(order);
            return order;
        }

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="orderId">
        /// The order ID to remove.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order RemoveOrder(string email, int orderId)
        {
            var order = this.orders.Find(o => o.Id == orderId);
            this.orders.Remove(order);
            return order;
        }

        /// <summary>
        /// Update order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order UpdateOrder(Order order)
        {
            var orderToUpdate = this.orders.Find(order1 => order1.Id == order.Id);
            this.orders.RemoveAt(orderToUpdate.Id);
            this.orders.Insert(orderToUpdate.Id, order);
            return order;
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
        /// The get my recent.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Model.Orders.Order].
        /// </returns>
        public List<Order> GetMyRecent(string email)
        {
            return new List<Order>();
        }

        /// <summary>
        /// The get my history.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<Order> GetMyHistory(string email)
        {
            return null;
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public void SaveChanges()
        {
        }
    }
}