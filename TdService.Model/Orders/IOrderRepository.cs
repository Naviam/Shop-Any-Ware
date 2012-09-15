// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOrderRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IOrderRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for order repository.
    /// </summary>
    public interface IOrderRepository
    {
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
        Order AddOrder(string email, Order order);

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
        Order RemoveOrder(string email, int orderId);

        /// <summary>
        /// Update order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        Order UpdateOrder(Order order);

        /// <summary>
        /// Get order details.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Order details.
        /// </returns>
        Order GetOrderById(int orderId);

        /// <summary>
        /// The get my recent.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Model.Orders.Order].
        /// </returns>
        List<Order> GetMyRecent(string email);

        /// <summary>
        /// The get my history.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        List<Order> GetMyHistory(string email);

        /// <summary>
        /// The get all new orders paged.
        /// </summary>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        List<Order> GetAllNewOrdersPaged(int skip, int take);

        /// <summary>
        /// The get all received orders paged.
        /// </summary>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        List<Order> GetAllReceivedOrdersPaged(int skip, int take);

        /// <summary>
        /// The get all return requested orders paged.
        /// </summary>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        List<Order> GetAllReturnRequestedOrdersPaged(int skip, int take);
    }
}