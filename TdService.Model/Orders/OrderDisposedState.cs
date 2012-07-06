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
    /// <summary>
    /// Describes the disposed order behavior.
    /// </summary>
    public class OrderDisposedState : IOrderState
    {
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
    }
}