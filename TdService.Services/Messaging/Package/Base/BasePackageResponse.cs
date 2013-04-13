// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePackageResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The base package response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package.Base
{
    using System;

    /// <summary>
    /// The base package response.
    /// </summary>
    public abstract class BasePackageResponse : ResponseBase
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
        /// Gets or sets Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the dispatch method.
        /// </summary>
        public int DispatchMethod { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether can be assembled.
        /// </summary>
        public bool CanBeAssembled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether package can be paid.
        /// </summary>
        public bool CanBePaidFor { get; set; }

        /// <summary>
        /// Gets or sets Weight Pounds.
        /// </summary>
        public decimal TotalWeight { get; set; }

        /// <summary>
        /// Gets or sets the dimensions length.
        /// </summary>
        public decimal DimensionsLength { get; set; }

        /// <summary>
        /// Gets or sets the dimensions height.
        /// </summary>
        public decimal DimensionsHeight { get; set; }

        /// <summary>
        /// Gets or sets the dimensions width.
        /// </summary>
        public decimal DimensionsWidth { get; set; }

        /// <summary>
        /// Gets or sets the dimensions girth.
        /// </summary>
        public decimal DimensionsGirth { get; set; }

        /// <summary>
        /// Gets or sets Tracking Number.
        /// </summary>
        public string TrackingNumber { get; set; } 
    }
}
