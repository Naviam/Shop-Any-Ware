// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveItemBackToOriginalOrderViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move item back to original order view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Item
{
    /// <summary>
    /// The move item back to original order view model.
    /// </summary>
    public class MoveItemBackToOriginalOrderViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        public ItemViewModel Item { get; set; }

        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
