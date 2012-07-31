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
        /// Gets a value indicating whether order can be received.
        /// </summary>
        bool CanBeReceived { get; }

        /// <summary>
        /// Gets a value indicating whether can items be modified.
        /// </summary>
        bool CanItemsBeModified { get; }

        /// <summary>
        /// Gets a value indicating whether can be modified.
        /// </summary>
        bool CanBeModified { get; }

        /// <summary>
        /// Gets a value indicating whether can be requested for return.
        /// </summary>
        bool CanBeRequestedForReturn { get; }

        /// <summary>
        /// Gets a value indicating whether can be returned.
        /// </summary>
        bool CanBeReturned { get; }

        /// <summary>
        /// Gets a value indicating whether can be disposed.
        /// </summary>
        bool CanBeDisposed { get; }

        /// <summary>
        /// Gets a value indicating whether can be removed.
        /// </summary>
        bool CanBeRemoved { get; }
    }
}