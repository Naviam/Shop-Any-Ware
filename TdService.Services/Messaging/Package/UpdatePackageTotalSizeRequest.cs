// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdatePackageTotalSizeRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The update package total size request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The update package total size request.
    /// </summary>
    public class UpdatePackageTotalSizeRequest : RequestBase
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
