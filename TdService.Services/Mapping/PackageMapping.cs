// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageMapping.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using System.Collections.Generic;
    using AutoMapper;
    using TdService.Model.Packages;
    using TdService.Services.Messaging.Package;
    using TdService.Services.ViewModels.Package;

    /// <summary>
    /// The package mapping.
    /// </summary>
    public static class PackageMapping
    {
        /// <summary>
        /// Convert collection of packages to collection of get recent packages responses.
        /// </summary>
        /// <param name="packages">
        /// The list of packages.
        /// </param>
        /// <returns>
        /// The collection of get recent packages responses.
        /// </returns>
        public static List<GetRecentPackagesResponse> ConvertToGetRecentPackagesResponseCollection(this List<Package> packages)
        {
            return Mapper.Map<List<Package>, List<GetRecentPackagesResponse>>(packages);
        }

        /// <summary>
        /// Convert package to add package response.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The add package response.
        /// </returns>
        public static AddPackageResponse ConvertToAddPackageResponse(this Package package)
        {
            return Mapper.Map<Package, AddPackageResponse>(package);
        }

        /// <summary>
        /// Convert add package response to package view model.
        /// </summary>
        /// <param name="response">
        /// The add package response message.
        /// </param>
        /// <returns>
        /// The package view model.
        /// </returns>
        public static PackageViewModel ConvertToPackageViewModel(this AddPackageResponse response)
        {
            return Mapper.Map<AddPackageResponse, PackageViewModel>(response);
        }

        /// <summary>
        /// Convert list of get recent packages responses to list of package view models.
        /// </summary>
        /// <param name="responses">
        /// The list of get recent packags responses.
        /// </param>
        /// <returns>
        /// The list of package view models.
        /// </returns>
        public static List<PackageViewModel> ConvertToPackageViewModelCollection(this List<GetRecentPackagesResponse> responses)
        {
            return Mapper.Map<List<GetRecentPackagesResponse>, List<PackageViewModel>>(responses);
        }
    }
}