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
        /// Gets Status.
        /// </summary>
        OrderStatus Status { get; }
    }
}