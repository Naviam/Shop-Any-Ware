﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPackageResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The add package response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    using System;

    /// <summary>
    /// The add package response.
    /// </summary>
    public class AddPackageResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the delivery address id.
        /// </summary>
        public int DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets the delivery address name.
        /// </summary>
        public string DeliveryAddressName { get; set; }

        /// <summary>
        /// Gets or sets the dispatch method.
        /// </summary>
        public string DispatchMethod { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the dispatched date.
        /// </summary>
        public DateTime DispatchedDate { get; set; }

        /// <summary>
        /// Gets or sets the delivered date.
        /// </summary>
        public DateTime DeliveredDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}