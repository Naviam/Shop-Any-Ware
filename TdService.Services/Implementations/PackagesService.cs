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
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
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
        public List<GetRecentPackagesResponse> GetRecent(GetRecentPackagesRequest request)
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
            var packageResult = this.packageRepository.AddPackage(request.IdentityToken, newPackage);
            return packageResult.ConvertToAddPackageResponse();
        }

        /// <summary>
        /// Remove package completely.
        /// </summary>
        /// <param name="request">
        /// The remove package request.
        /// </param>
        /// <returns>
        /// The remove package response.
        /// </returns>
        public RemovePackageResponse RemovePackage(RemovePackageRequest request)
        {
            var response = new RemovePackageResponse { MessageType = MessageType.Success };

            var user = this.userRepository.GetUserWithPackagesByEmail(request.IdentityToken);

            if (user != null)
            {
                try
                {
                    var result = user.RemovePackage(request.Id);
                    if (result)
                    {
                        this.packageRepository.RemovePackage(request.Id);
                        this.packageRepository.SaveChanges();
                    }
                    else
                    {
                        response.MessageType = MessageType.Warning;
                        response.Message = DashboardViewResources.PackageCannotBeRemoved;
                    }
                }
                catch (Exception ex)
                {
                    response.MessageType = MessageType.Error;
                    response.Message = ex.Message;
                }
            }

            return response;
        }
    }
}