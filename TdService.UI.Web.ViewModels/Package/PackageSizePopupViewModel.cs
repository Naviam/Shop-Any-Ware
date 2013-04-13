// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageSizePopupViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The package size popup view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Package
{
    /// <summary>
    /// The package size popup view model.
    /// </summary>
    public class PackageSizePopupViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets Weight Pounds.
        /// </summary>
        public int WeightPounds { get; set; }

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
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
