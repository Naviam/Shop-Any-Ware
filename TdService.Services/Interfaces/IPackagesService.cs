// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackagesService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The PackagesService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Package;

    /// <summary>
    /// The PackagesService interface.
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
        List<GetRecentPackagesResponse> GetRecentPackages(GetRecentPackagesRequest request);

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
    }
}