// -----------------------------------------------------------------------
// <copyright file="IOrderState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    /// <summary>
    /// Interface that describes order state.
    /// </summary>
    public interface IOrderState
    {
        /// <summary>
        /// Can this order be received (status changed to received).
        /// </summary>
        bool CanBeReceived { get; }

        /// <summary>
        /// Flag that says whether items are editable in this order.
        /// </summary>
        bool CanItemsBeModified { get; }

        /// <summary>
        /// Flag that says whether this order is editable.
        /// </summary>
        bool CanBeModified { get; }

        /// <summary>
        /// Flag that says whether this order can be requested for returned.
        /// </summary>
        bool CanBeRequestedForReturn { get; }

        /// <summary>
        /// Flag that says whether this order can be returned.
        /// </summary>
        bool CanBeReturned { get; }

        /// <summary>
        /// Flag that says whether this order can be disposed.
        /// </summary>
        bool CanBeDisposed { get; }

        /// <summary>
        /// Flag that says whether this order can be removed.
        /// </summary>
        bool CanBeRemoved { get; }
    }
}