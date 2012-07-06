// -----------------------------------------------------------------------
// <copyright file="OrderReceivedState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;

    /// <summary>
    /// Describes the received order behavior.
    /// </summary>
    public class OrderReceivedState : IOrderState
    {
        /// <summary>
        /// Gets Status.
        /// </summary>
        public OrderStatus Status
        {
            get
            {
                return OrderStatus.Received;
            }
        }
    }
}