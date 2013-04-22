﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddOrderRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The add order request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    using System;

    /// <summary>
    /// The add order request.
    /// </summary>
    public class AddOrderRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets retailer url.
        /// </summary>
        public string RetailerUrl { get; set; }

        /// <summary>
        /// Gets or sets created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether created by operator.
        /// </summary>
        public bool CreatedByOperator { get; set; }
    }
}