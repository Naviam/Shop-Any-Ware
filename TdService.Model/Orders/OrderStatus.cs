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
        /// Returned to seller.
        /// </summary>
        Returned = 2,

        /// <summary>
        /// Disposed order.
        /// </summary>
        Disposed = 3
    }
}