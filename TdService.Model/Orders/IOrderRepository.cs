// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOrderRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IOrderRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TdService.Model.Items;

namespace TdService.Model.Orders
{
    using System;
    using System.Collections.Generic;
    using Model;

    /// <summary>
    /// Interface for order repository.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="order">
        /// The order to add.
        /// </param>
        void AddOrder(Order order);

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="order">
        /// The order to remove.
        /// </param>
        void RemoveOrder(Order order);

        /// <summary>
        /// Update order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        void UpdateOrder(Order order);

        /// <summary>
        /// Get all orders.
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
        IEnumerable<Order> GetAllOrders(object sortDirection, string sortExpression, string filterExpression, int pageSize = 20);

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
        IEnumerable<Order> GetUserOrders(string username, object sortDirection, string sortExpression, string filterExpression, int pageSize = 20);

        /// <summary>
        /// Get order details.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Order details.
        /// </returns>
        Order GetOrderDetails(int orderId);

        /// <summary>
        /// Request photos.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        void RequestPhotos(int orderId);

        /// <summary>
        /// Add photos.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="picture">
        /// The picture.
        /// </param>
        void AddPhotos(int orderId, IEnumerable<ItemImage> picture);

        /// <summary>
        /// Update order status.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="newStatus">
        /// The new status.
        /// </param>
        void UpdateOrderStatus(int orderId, OrderStatus newStatus);

        /// <summary>
        /// Update arrival date.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="arrivalDate">
        /// The arrival date.
        /// </param>
        void UpdateArrivalDate(int orderId, DateTime arrivalDate);

        /// <summary>
        /// Update order weight.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="weight">
        /// The weight.
        /// </param>
        void UpdateOrderWeight(int orderId, Weight weight);
    }
}