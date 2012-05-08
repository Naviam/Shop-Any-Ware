// -----------------------------------------------------------------------
// <copyright file="OrderCanceledState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;

    /// <summary>
    /// Describes the newly created order behavior.
    /// </summary>
    public class OrderNewState : IOrderState
    {
        /// <summary>
        /// Gets Order Status.
        /// </summary>
        public OrderStatus Status
        {
            get { return OrderStatus.Canceled; }
        }

        /// <summary>
        /// Indicates whether an order can be canceled.
        /// </summary>
        /// <returns>
        /// Boolean value.
        /// </returns>
        public bool CanCancel()
        {
            return true;
        }

        /// <summary>
        /// Cancel order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Exception message will indicate the reason why order can't be canceled.
        /// </exception>
        public void Cancel(Order order)
        {
            throw new NotImplementedException("This order is already canceled.");
        }
    }
}