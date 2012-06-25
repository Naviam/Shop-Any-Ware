// -----------------------------------------------------------------------
// <copyright file="OrderRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Orders;

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

        /// <summary>
        /// Get user's orders.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
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
        /// Collection of user's orders.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        public IEnumerable<Order> GetUserOrders(
            string username, 
            object sortDirection, 
            string sortExpression, 
            string filterExpression, 
            int pageSize = 20)
        {
            throw new NotImplementedException();
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
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        public Order GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Request photos.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        public void RequestPhotos(int orderId)
        {
        }

        /// <summary>
        /// Add photos.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="picture">
        /// The picture.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// not yet implemented
        /// </exception>
        public void AddPhotos(int orderId, IEnumerable<ItemImage> picture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update order status.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="newStatus">
        /// The new status.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// not yet implemented
        /// </exception>
        public void UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update arrival date.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="arrivalDate">
        /// The arrival date.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// not yet implemented
        /// </exception>
        public void UpdateArrivalDate(int orderId, DateTime arrivalDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update order weight
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// not yet implemented
        /// </exception>
        public void UpdateOrderWeight(int orderId, Weight weight)
        {
            throw new NotImplementedException();
        }
    }
}
