// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayForPackageViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The pay for package view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Package
{
    /// <summary>
    /// The pay for package view model.
    /// </summary>
    public class PayForPackageViewModel : PackageViewModel
    {
        /// <summary>
        /// Gets or sets the wallet amount.
        /// </summary>
        public decimal WalletAmount { get; set; }
    }
}
