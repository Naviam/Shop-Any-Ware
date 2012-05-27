// -----------------------------------------------------------------------
// <copyright file="OrderCanceledState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Items;

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
        /// Gets a value indicating whether items can be added to order.
        /// </summary>
        public bool CanAddItems
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the order can be canceled.
        /// </summary>
        bool IOrderState.CanCancel
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Add item to this order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Message describes 
        /// </exception>
        public void AddItem(Item item)
        {
            throw new NotImplementedException("Items cannot be added to canceled order.");
        }

        public void AddItems(IEnumerable<Item> items)
        {
            throw new System.NotImplementedException();
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