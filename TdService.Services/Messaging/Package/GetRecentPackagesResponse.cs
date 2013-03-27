// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetRecentPackagesResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get recent packages response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    using System;

    /// <summary>
    /// The get recent packages response.
    /// </summary>
    public class GetRecentPackagesResponse : ResponseBase
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
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets the dispatch method.
        /// </summary>
        public int? DispatchMethod { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether can be modified.
        /// </summary>
        public bool CanBeModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be sent.
        /// </summary>
        public bool CanBeSent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be removed.
        /// </summary>
        public bool CanBeRemoved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be disposed.
        /// </summary>
        public bool CanBeDisposed { get; set; }
    }
}