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
    using TdService.Infrastructure.Logging;
    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Model.Packages;
    using TdService.Model.Shipping;
    using TdService.Resources;
    using TdService.Resources.Views;
    using TdService.Services.Base;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Package;

    /// <summary>
    /// The packages service.
    /// </summary>
    public class PackagesService : ServiceBase, IPackagesService
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
        public PackagesService(IPackageRepository packageRepository, IUserRepository userRepository, ILogger logger)
            : base(logger)
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
        /// The get history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The list of <see cref="GetRecentPackagesResponse"/>.
        /// </returns>
        public List<GetRecentPackagesResponse> GetHistory(GetRecentPackagesRequest request)
        {
            var user = this.userRepository.GetUserWithPackagesByEmail(request.IdentityToken);
            if (user != null)
            {
                var recentPackages = user.GetHistoryPackages();
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
            var newPackage = new Package { Name = request.Name, CreatedDate = DateTime.UtcNow, Dimensions = new Dimensions() };
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
                        //this.packageRepository.SaveChanges();
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


        public ChangePackageDeliveryAddressResponse ChangePackageDeliveryAddress(ChangePackageDeliveryAddressRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.DeliveryAddressId = request.DeliverAddressId;
                this.packageRepository.UpdatePackage(package);
                return new ChangePackageDeliveryAddressResponse { MessageType = MessageType.Success, Message =string.Format(CommonResources.PackageDeliveryAddressChanged,package.Id) };
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return new ChangePackageDeliveryAddressResponse { MessageType = MessageType.Error, Message = CommonResources.ChangePackageDeliveryAddressError };
            }
        }

        public ChangePackageDeliveryMethodResponse ChangePackageDispatchMethod(ChangePackageDeliveryMethodRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.DispatchMethod = (DispatchMethod)Enum.Parse(typeof(DispatchMethod),request.DispatchMethodId.ToString());
                this.packageRepository.UpdatePackage(package);
                return new ChangePackageDeliveryMethodResponse { MessageType = MessageType.Success, Message = string.Format(CommonResources.PackageDispatchMethodChanged, package.Id) };
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                return new ChangePackageDeliveryMethodResponse { MessageType = MessageType.Error, Message = CommonResources.ChangePackageDispatchMethodError };
            }
        }
    }
}