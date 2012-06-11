// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderStatus.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the OrderStatus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    /// <summary>
    /// Order status.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Waiting arrival.
        /// </summary>
        Created = 0,

        /// <summary>
        /// Created on request for order.
        /// </summary>
        CreatedOnRequest = 1,

        /// <summary>
        /// Incoming order is processing by operator.
        /// </summary>
        Receiving = 2,

        /// <summary>
        /// Received and ready for package creation.
        /// </summary>
        Received = 3,

        /// <summary>
        /// Return of an order has been requested by an user.
        /// </summary>
        ReturnRequested = 4,

        /// <summary>
        /// Return is processed by operator.
        /// </summary>
        ReturnInProgress = 5,

        /// <summary>
        /// Returned to seller.
        /// </summary>
        Returned = 6,

        /// <summary>
        /// Disposed order.
        /// </summary>
        Disposed = 7
    }
}