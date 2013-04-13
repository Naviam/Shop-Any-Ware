// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageItemsViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package item view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Item
{
    using System.Collections.Generic;

    /// <summary>
    /// The package item view model.
    /// </summary>
    public class PackageItemsViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<ItemViewModel> Items { get; set; }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }
    }
}