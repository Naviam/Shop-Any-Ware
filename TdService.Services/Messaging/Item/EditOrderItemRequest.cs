// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditOrderItemRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The edit order item request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The edit order item request.
    /// </summary>
    public class EditOrderItemRequest : AddItemToOrderRequest
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether operator mode.
        /// </summary>
        public bool OperatorMode { get; set; }
    }
}
