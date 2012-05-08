// -----------------------------------------------------------------------
// <copyright file="OrderReceivedState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;

    /// <summary>
    /// Describes the received order behavior.
    /// </summary>
    public class OrderReceivedState : IOrderState
    {
        /// <summary>
        /// Gets Order Status.
        /// </summary>
        public OrderStatus Status
        {
            get { return OrderStatus.Received; }
        }

        /// <summary>
        /// Indicates whether an order can be canceled.
        /// </summary>
        /// <returns>
        /// Boolean value.
        /// </returns>
        public bool CanCancel()
        {
            return false;
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
            throw new NotImplementedException("Already received order can't be canceled.");
        }
    }
}