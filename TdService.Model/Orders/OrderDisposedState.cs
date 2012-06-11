// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderDisposedState.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Describes the disposed order behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using TdService.Model.Items;

    /// <summary>
    /// Describes the disposed order behavior.
    /// </summary>
    public class OrderDisposedState : IOrderState
    {
        #region Implementation of IOrderState

        /// <summary>
        /// Gets Status.
        /// </summary>
        public OrderStatus Status
        {
            get
            {
                return OrderStatus.Disposed;
            }
        }

        /// <summary>
        /// Receive order.
        /// </summary>
        public void ReceiveOrder()
        {
        }

        /// <summary>
        /// Process incoming order.
        /// </summary>
        public void ProcessIncomingOrder()
        {
        }

        /// <summary>
        /// Request order return.
        /// </summary>
        public void RequestOrderReturn()
        {
        }

        /// <summary>
        /// Process order for return.
        /// </summary>
        public void ProcessOrderForReturn()
        {
        }

        /// <summary>
        /// Return order.
        /// </summary>
        public void ReturnOrder()
        {
        }

        /// <summary>
        /// Dispose order.
        /// </summary>
        public void DisposeOrder()
        {
        }

        /// <summary>
        /// Change order's status.
        /// </summary>
        /// <param name="newStatus">
        /// The new status.
        /// </param>
        public void ChangeStatusTo(OrderStatus newStatus)
        {
        }

        /// <summary>
        /// Get item's details.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// Order's item details.
        /// </returns>
        public Item GetItemDetails(int id)
        {
            return null;
        }

        /// <summary>
        /// Add item to the order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void AddItem(Item item)
        {
        }

        /// <summary>
        /// Update item details.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void UpdateItem(Item item)
        {
        }

        /// <summary>
        /// Remove item from the order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void RemoveItem(Item item)
        {
        }

        /// <summary>
        /// Add item's photo.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="photo">
        /// The photo.
        /// </param>
        public void AddItemPhoto(Item item, string photo)
        {
        }

        /// <summary>
        /// Remove item's photo.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void RemoveItemPhoto(Item item)
        {
        }

        /// <summary>
        /// Find order by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// Order details.
        /// </returns>
        public Order Find(int id)
        {
            return null;
        }

        /// <summary>
        /// Add new order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        public void Add(Order order)
        {
        }

        /// <summary>
        /// Edit order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        public void Edit(Order order)
        {
        }

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="order">
        /// The order to cancel.
        /// </param>
        public void Remove(Order order)
        {
        }

        #endregion
    }
}