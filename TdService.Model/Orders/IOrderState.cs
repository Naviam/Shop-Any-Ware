// -----------------------------------------------------------------------
// <copyright file="IOrderState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System.Collections.Generic;
    using Items;

    /// <summary>
    /// Interface that describes order state.
    /// </summary>
    public interface IOrderState
    {
        /// <summary>
        /// Gets Status.
        /// </summary>
        OrderStatus Status { get; }

        /// <summary>
        /// Gets a value indicating whether items can be added to order.
        /// </summary>
        bool CanAddItems { get; }

        /// <summary>
        /// Gets a value indicating whether order can be canceled.
        /// </summary>
        bool CanCancel { get; }

        /// <summary>
        /// Add item to the order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void AddItem(Item item);

        /// <summary>
        /// Add collection of items to the order.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        void AddItems(IEnumerable<Item> items);

        /// <summary>
        /// Cancel order.
        /// </summary>
        /// <param name="order">
        /// The order to cancel.
        /// </param>
        void Cancel(Order order);
    }
}