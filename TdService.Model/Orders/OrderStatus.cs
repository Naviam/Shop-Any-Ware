﻿// --------------------------------------------------------------------------------------------------------------------
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
        WaitingArrival = 0,

        /// <summary>
        /// Arrived status.
        /// </summary>
        Arrived = 1,

        /// <summary>
        /// Processed status.
        /// </summary>
        Processed = 2,
    }
}