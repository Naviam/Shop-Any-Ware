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
        /// Just created order.
        /// </summary>
        New = 0,

        /// <summary>
        /// Received and ready for package creation.
        /// </summary>
        Received = 1,

        /// <summary>
        /// Return of an order was requested by shopper.
        /// </summary>
        ReturnRequested = 2,

        /// <summary>
        /// Returned to seller.
        /// </summary>
        Returned = 3,

        /// <summary>
        /// Disposed order.
        /// </summary>
        Disposed = 4
    }
}