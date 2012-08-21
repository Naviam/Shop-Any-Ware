// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackagesService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The Packages Service interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Package;

    /// <summary>
    /// The Packages Service interface.
    /// </summary>
    public interface IPackagesService
    {
        /// <summary>
        /// Get recent packages for user.
        /// </summary>
        /// <param name="request">
        /// The get recent packages request message.
        /// </param>
        /// <returns>
        /// The collection of get recent packages response messages.
        /// </returns>
        List<GetRecentPackagesResponse> GetRecent(GetRecentPackagesRequest request);

        /// <summary>
        /// Add new package.
        /// </summary>
        /// <param name="request">
        /// The add package request message.
        /// </param>
        /// <returns>
        /// The add package response message.
        /// </returns>
        AddPackageResponse AddPackage(AddPackageRequest request);

        /// <summary>
        /// Remove package completely.
        /// </summary>
        /// <param name="request">
        /// The remove package request.
        /// </param>
        /// <returns>
        /// The remove package response.
        /// </returns>
        RemovePackageResponse RemovePackage(RemovePackageRequest request);
    }
}