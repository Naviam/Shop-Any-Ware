// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackagesService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The packages service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using TdService.Model.Membership;
    using TdService.Model.Packages;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Package;

    /// <summary>
    /// The packages service.
    /// </summary>
    public class PackagesService : IPackagesService
    {
        /// <summary>
        /// The package repository.
        /// </summary>
        private readonly IPackageRepository packageRepository;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackagesService"/> class.
        /// </summary>
        /// <param name="packageRepository">
        /// The package repository.
        /// </param>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        public PackagesService(IPackageRepository packageRepository, IUserRepository userRepository)
        {
            this.packageRepository = packageRepository;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Get recent packages for user.
        /// </summary>
        /// <param name="request">
        /// The get recent packages request message.
        /// </param>
        /// <returns>
        /// The collection of get recent packages response messages.
        /// </returns>
        public List<GetRecentPackagesResponse> GetRecentPackages(GetRecentPackagesRequest request)
        {
            var user = this.userRepository.GetUserWithPackagesByEmail(request.IdentityToken);
            if (user != null)
            {
                var recentPackages = user.GetRecentPackages();
                return recentPackages.ConvertToGetRecentPackagesResponseCollection();
            }

            return null;
        }

        /// <summary>
        /// Add new package.
        /// </summary>
        /// <param name="request">
        /// The add package request message.
        /// </param>
        /// <returns>
        /// The add package response message.
        /// </returns>
        public AddPackageResponse AddPackage(AddPackageRequest request)
        {
            var newPackage = new Package { Name = request.Name, CreatedDate = DateTime.UtcNow };
            var packageResult = this.packageRepository.AddPackage(newPackage);
            this.packageRepository.SaveChanges();

            this.userRepository.AttachPackage(request.IdentityToken, packageResult.Id);
            this.userRepository.SaveChanges();

            return packageResult.ConvertToAddPackageResponse();
        }
    }
}