// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangePackageDeliveryMethodRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The change package delivery method request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The change package delivery method request.
    /// </summary>
    public class ChangePackageDeliveryMethodRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }

        /// <summary>
        /// Gets or sets the dispatch method id.
        /// </summary>
        public int DispatchMethodId { get; set; }
    }
}
