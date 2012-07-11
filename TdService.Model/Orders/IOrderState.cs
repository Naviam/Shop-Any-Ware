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
        /// Flag that says whether items are editable in this order.
        /// </summary>
        bool CanEditItems { get; }

        /// <summary>
        /// Flag that says whether this order is editable.
        /// </summary>
        bool CanEditOrder { get; }

        /// <summary>
        /// Flag that says whether this order can be returned.
        /// </summary>
        bool CanRequestOrderReturn { get; }

        /// <summary>
        /// Flag that says whether this order can be disposed.
        /// </summary>
        bool CanDisposeOrder { get; }

        /// <summary>
        /// Flag that says whether this order can be removed.
        /// </summary>
        bool CanRemoveOrder { get; }
    }
}