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
        void UpdateOrder(Order order);

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
    }
}