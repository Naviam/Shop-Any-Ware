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
        /// The convert to assemble package response.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The <see cref="AssemblePackageResponse"/>.
        /// </returns>
        public static AssemblePackageResponse ConvertToAssemblePackageResponse(this Package package)
        {
            return Mapper.Map<Package, AssemblePackageResponse>(package);
        }

        /// <summary>
        /// The convert to package assembled response.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The <see cref="PackageAssembledResponse"/>.
        /// </returns>
        public static PackageAssembledResponse ConvertToPackageAssembledResponse(this Package package)
        {
            return Mapper.Map<Package, PackageAssembledResponse>(package);
        }

        /// <summary>
        /// The convert to pay for package response.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The <see cref="PayForPackageResponse"/>.
        /// </returns>
        public static PayForPackageResponse ConvertToPayForPackageResponse(this Package package)
        {
            return Mapper.Map<Package, PayForPackageResponse>(package);
        }

        /// <summary>
        /// The convert to send package response.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The <see cref="SendPackageResponse"/>.
        /// </returns>
        public static SendPackageResponse ConvertToSendPackageResponse(this Package package)
        {
            return Mapper.Map<Package, SendPackageResponse>(package);
        }

        /// <summary>
        /// The convert to users packages collection.
        /// </summary>
        /// <param name="packages">
        /// The packages.
        /// </param>
        /// <returns>
        /// The <see cref="GetUsersPackagesResponse"/>.
        /// </returns>
        public static GetUsersPackagesResponse ConvertToUsersPackagesCollection(this List<Package> packages)
        {
            return new GetUsersPackagesResponse
                {
                    UsersPackages = Mapper.Map<List<Package>, List<UserPackageResponse>>(packages)
                };
        }

        /// <summary>
        /// The convert to update package total size response.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The <see cref="UpdatePackageTotalSizeResponse"/>.
        /// </returns>
        public static UpdatePackageTotalSizeResponse ConvertToUpdatePackageTotalSizeResponse(this Package package)
        {
            return Mapper.Map<Package, UpdatePackageTotalSizeResponse>(package);
        }
    }
}