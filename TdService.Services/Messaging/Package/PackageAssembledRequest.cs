// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageAssembledRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The package assembled request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The package assembled request.
    /// </summary>
    public class PackageAssembledRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
