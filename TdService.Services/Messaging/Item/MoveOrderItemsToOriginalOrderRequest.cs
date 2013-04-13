// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveOrderItemsToOriginalOrderRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move order items to original order request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The move order items to original order request.
    /// </summary>
    public class MoveOrderItemsToOriginalOrderRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
