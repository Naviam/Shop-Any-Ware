// -----------------------------------------------------------------------
// <copyright file="OrderCanceledState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    /// <summary>
    /// Describes the cancelled order behavior.
    /// </summary>
    public class OrderCanceledState : IOrderState
    {
        /// <summary>
        /// Gets Order Status.
        /// </summary>
        public OrderStatus Status
        {
            get { return OrderStatus.New; }
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
        /// The order to cancel.
        /// </param>
        public void Cancel(Order order)
        {
            order.Change(new OrderCanceledState());
        }
    }
}