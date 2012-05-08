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
        New = 0,

        /// <summary>
        /// Arrived order.
        /// </summary>
        Received = 1,

        /// <summary>
        /// Ready for package creation.
        /// </summary>
        Ready = 2,

        /// <summary>
        /// Cancelled status.
        /// </summary>
        Canceled = 3,

        /// <summary>
        /// Returned to seller.
        /// </summary>
        Returned = 4
    }
}