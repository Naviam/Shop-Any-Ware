// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveItemBackToOriginalOrderRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move item back to original order request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The move item back to original order request.
    /// </summary>
    public class MoveItemBackToOriginalOrderRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        public int ItemId { get; set; }
    }
}
