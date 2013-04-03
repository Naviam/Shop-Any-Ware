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
        /// 
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public static AssemblePackageResponse ConvertToAssemblePackageResponse(this Package package)
        {
            return Mapper.Map<Package, AssemblePackageResponse>(package);
        }

        public static PackageAssembledResponse ConvertToPackageAssembledResponse(this Package package)
        {
            return Mapper.Map<Package, PackageAssembledResponse>(package);
        }

        public static PayForPackageResponse ConvertToPayForPackageResponse(this Package package)
        {
            return Mapper.Map<Package, PayForPackageResponse>(package);
        }

        public static SendPackageResponse ConvertToSendPackageResponse(this Package package)
        {
            return Mapper.Map<Package, SendPackageResponse>(package);
        }

        public static GetUsersPackagesResponse ConvertToUsersPackagesCollection(this List<Package> packages)
        {
            return new GetUsersPackagesResponse
                {
                    UsersPackages = Mapper.Map<List<Package>, List<TdService.Services.Messaging.Package.GetUsersPackagesResponse.UserPackage>>(packages)
                };
        }
    }
}