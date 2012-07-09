// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderCreatedState.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Describes the newly created order behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;

    /// <summary>
    /// Describes the newly created order behavior.
    /// </summary>
    public class OrderCreatedState : IOrderState
    {
        /// <summary>
        /// Gets the created date.
        /// </summary>
        public DateTime CreatedDate
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        /// <summary>
        /// Get received date.
        /// </summary>
        public DateTime ReceivedDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Gets Order Status.
        /// </summary>
        public OrderStatus Status
        {
            get
            {
                return OrderStatus.Created;
            }
        }
    }
}