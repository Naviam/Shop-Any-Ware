// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditPackageItemRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The edit package item request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The edit package item request.
    /// </summary>
    public class EditPackageItemRequest : AddItemToOrderRequest
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
