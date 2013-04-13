// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeTrackingNumberRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The change tracking number request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The change tracking number request.
    /// </summary>
    public class ChangeTrackingNumberRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// Gets or sets the tracking number.
        /// </summary>
        public string TrackingNumber { get; set; }
    }
}
