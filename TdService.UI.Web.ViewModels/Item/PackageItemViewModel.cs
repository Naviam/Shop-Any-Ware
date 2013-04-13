// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageItemViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The package item view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Item
{
    /// <summary>
    /// The package item view model.
    /// </summary>
    public class PackageItemViewModel : ItemViewModel
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether operator mode.
        /// </summary>
        public bool OperatorMode { get; set; }
    }
}
