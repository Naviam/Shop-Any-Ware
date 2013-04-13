// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayForPackageRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The pay for package request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The pay for package request.
    /// </summary>
    public class PayForPackageRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
