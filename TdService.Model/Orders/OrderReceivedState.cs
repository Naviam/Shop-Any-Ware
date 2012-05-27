// -----------------------------------------------------------------------
// <copyright file="OrderReceivedState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Items;

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

        public bool CanAddItems
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IOrderState.CanCancel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void AddItems(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
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