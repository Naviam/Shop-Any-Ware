// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoveOrderItemToExistingPackageViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The move order item to existing package view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Item
{
    /// <summary>
    /// The move order item to existing package view model.
    /// </summary>
    public class MoveOrderItemToExistingPackageViewModel : ViewModelBase
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
