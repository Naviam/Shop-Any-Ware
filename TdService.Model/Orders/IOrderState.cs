// -----------------------------------------------------------------------
// <copyright file="IOrderState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using TdService.Model.Items;

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
        /// Receive order.
        /// </summary>
        void ReceiveOrder();

        /// <summary>
        /// Process incoming order.
        /// </summary>
        void ProcessIncomingOrder();

        /// <summary>
        /// Request order return.
        /// </summary>
        void RequestOrderReturn();

        /// <summary>
        /// Process order for return.
        /// </summary>
        void ProcessOrderForReturn();

        /// <summary>
        /// Return order.
        /// </summary>
        void ReturnOrder();

        /// <summary>
        /// Dispose order.
        /// </summary>
        void DisposeOrder();

        /// <summary>
        /// Change order's status.
        /// </summary>
        /// <param name="newStatus">
        /// The new status.
        /// </param>
        void ChangeStatusTo(OrderStatus newStatus);

        #region Working with items

        /// <summary>
        /// Get item's details.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// Order's item details.
        /// </returns>
        Item GetItemDetails(int id);

        /// <summary>
        /// Add item to the order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void AddItem(Item item);

        /// <summary>
        /// Update item details.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void UpdateItem(Item item);

        /// <summary>
        /// Remove item from the order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void RemoveItem(Item item);

        /// <summary>
        /// Add item's photo.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="photo">
        /// The photo.
        /// </param>
        void AddItemPhoto(Item item, string photo);

        /// <summary>
        /// Remove item's photo.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void RemoveItemPhoto(Item item);

        #endregion

        #region Working with orders

        /// <summary>
        /// Find order by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// Order details.
        /// </returns>
        Order Find(int id);

        /// <summary>
        /// Add new order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        void Add(Order order);

        /// <summary>
        /// Edit order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        void Edit(Order order);

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="order">
        /// The order to cancel.
        /// </param>
        void Remove(Order order);

        #endregion
    }
}