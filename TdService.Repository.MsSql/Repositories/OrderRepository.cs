// -----------------------------------------------------------------------
// <copyright file="OrderRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Items;
    using TdService.Model.Orders;
    using TdService.Model.RFO;

    /// <summary>
    /// Order repository to work with orders in database.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="order">
        /// The order to add.
        /// </param>
        public void AddOrder(Order order)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Remove an order.
        /// </summary>
        /// <param name="order">
        /// The order to remove.
        /// </param>
        public void RemoveOrder(Order order)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Update the order.
        /// </summary>
        /// <param name="order">
        /// The order to update.
        /// </param>
        public void UpdateOrder(Order order)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Orders.Remove(order);
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get all orders from all users for operators.
        /// </summary>
        /// <param name="sortDirection">
        /// The sort direction.
        /// </param>
        /// <param name="sortExpression">
        /// The sort expression.
        /// </param>
        /// <param name="filterExpression">
        /// The filter expression.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// Collection of orders.
        /// </returns>
        public IEnumerable<Order> GetAllOrders(
            object sortDirection, string sortExpression, string filterExpression, int pageSize = 20)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Orders;
            }
        }

        public IEnumerable<Order> GetUserOrders(string username, object sortDirection, string sortExpression, string filterExpression, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        public void RequestPhotos(int orderId)
        {
            throw new NotImplementedException();
        }

        public void AddPhotos(int orderId, IEnumerable<ItemImage> picture)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public void UpdateArrivalDate(int orderId, DateTime arrivalDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderWeight(int orderId, Model.Weight weight)
        {
            throw new NotImplementedException();
        }
    }
}
