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
    using System.Globalization;

    using TdService.Infrastructure.Logging;
    using TdService.Model.Addresses;
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
        /// The address repository.
        /// </summary>
        private readonly IAddressRepository addressRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackagesService"/> class.
        /// </summary>
        /// <param name="packageRepository">
        /// The package repository.
        /// </param>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="addressRepository">
        /// The address Repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public PackagesService(IPackageRepository packageRepository, IUserRepository userRepository, IAddressRepository addressRepository, ILogger logger)
            : base(logger)
        {
            this.packageRepository = packageRepository;
            this.userRepository = userRepository;
            this.addressRepository = addressRepository;
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

        /// <summary>
        /// The change package delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ChangePackageDeliveryAddressResponse"/>.
        /// </returns>
        public ChangePackageDeliveryAddressResponse ChangePackageDeliveryAddress(ChangePackageDeliveryAddressRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.DeliveryAddressId = request.DeliverAddressId;
                this.packageRepository.UpdatePackage(package);
                var addr = this.addressRepository.GetDeliveryAddressDetails(request.DeliverAddressId);

                return new ChangePackageDeliveryAddressResponse
                           {
                               CountryCode = addr.Country.Code,
                               MessageType = MessageType.Success,
                               Message =
                                   string.Format(
                                       CommonResources.PackageDeliveryAddressChanged,
                                       package.Id)
                           };
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new ChangePackageDeliveryAddressResponse { MessageType = MessageType.Error, Message = CommonResources.ChangePackageDeliveryAddressError };
            }
        }

        /// <summary>
        /// The change package dispatch method.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ChangePackageDeliveryMethodResponse"/>.
        /// </returns>
        public ChangePackageDeliveryMethodResponse ChangePackageDispatchMethod(ChangePackageDeliveryMethodRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.DispatchMethod = (DispatchMethod)Enum.Parse(typeof(DispatchMethod), request.DispatchMethodId.ToString(CultureInfo.InvariantCulture));
                this.packageRepository.UpdatePackage(package);
                return new ChangePackageDeliveryMethodResponse { MessageType = MessageType.Success, Message = string.Format(CommonResources.PackageDispatchMethodChanged, package.Id) };
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new ChangePackageDeliveryMethodResponse { MessageType = MessageType.Error, Message = CommonResources.ChangePackageDispatchMethodError };
            }
        }

        /// <summary>
        /// The assemble package.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="AssemblePackageResponse"/>.
        /// </returns>
        public AssemblePackageResponse AssemblePackage(AssemblePackageRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.Status = PackageStatus.Assembling;
                this.packageRepository.UpdatePackage(package);
                var response = package.ConvertToAssemblePackageResponse();
                response.MessageType = MessageType.Success;
                response.Message = string.Format(PackageStatusResources.StatusChanged, PackageStatus.Assembling);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new AssemblePackageResponse { MessageType = MessageType.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// The package assembled.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="PackageAssembledResponse"/>.
        /// </returns>
        public PackageAssembledResponse PackageAssembled(PackageAssembledRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.Status = PackageStatus.Assembled;
                this.packageRepository.UpdatePackage(package);
                var response = package.ConvertToPackageAssembledResponse();
                response.MessageType = MessageType.Success;
                response.Message = string.Format(PackageStatusResources.StatusChanged, PackageStatus.Assembled);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new PackageAssembledResponse { MessageType = MessageType.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// The send package.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SendPackageResponse"/>.
        /// </returns>
        public SendPackageResponse SendPackage(SendPackageRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.Status = PackageStatus.Sent;
                this.packageRepository.UpdatePackage(package);
                var response = package.ConvertToSendPackageResponse();
                response.MessageType = MessageType.Success;
                response.Message = string.Format(PackageStatusResources.StatusChanged, PackageStatus.Sent);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new SendPackageResponse { MessageType = MessageType.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// The get users packages.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetUsersPackagesResponse"/>.
        /// </returns>
        public GetUsersPackagesResponse GetUsersPackages(GetUsersPackagesRequest request)
        {
            try
            {
                var packages = this.packageRepository.GetShoppersPackages(request.IncludeAssembling, request.IncludePaid, request.IncludeSent);
                var result = packages.ConvertToUsersPackagesCollection();
                return result;
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new GetUsersPackagesResponse { MessageType = MessageType.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// The update package total size.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="UpdatePackageTotalSizeResponse"/>.
        /// </returns>
        public UpdatePackageTotalSizeResponse UpdatePackageTotalSize(UpdatePackageTotalSizeRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.TotalWeight = request.WeightPounds;
                package.Dimensions.Girth = request.DimensionsGirth;
                package.Dimensions.Height = request.DimensionsHeight;
                package.Dimensions.Length = request.DimensionsLength;
                package.Dimensions.Width = request.DimensionsWidth;
                this.packageRepository.UpdatePackage(package);
                var response = package.ConvertToUpdatePackageTotalSizeResponse();
                response.MessageType = MessageType.Success;
                response.Message = DashboardViewResources.PackageSizeUpdated;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new UpdatePackageTotalSizeResponse { MessageType = MessageType.Error, Message = ex.Message };
            }
        }

        /// <summary>
        /// The change package tracking number.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ChangeTrackingNumberResponse"/>.
        /// </returns>
        public ChangeTrackingNumberResponse ChangePackageTrackingNumber(ChangeTrackingNumberRequest request)
        {
            try
            {
                var package = this.packageRepository.GetPackageById(request.PackageId);
                package.TrackingNumber = request.TrackingNumber;
                this.packageRepository.UpdatePackage(package);
                var response = new ChangeTrackingNumberResponse
                    { Message = DashboardViewResources.TrackingNumberUpdated, MessageType = MessageType.Success };
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
                return new ChangeTrackingNumberResponse
                           {
                               Message = DashboardViewResources.TrackingNumberUpdateError,
                               MessageType = MessageType.Error
                           };
            }
        }
    }
}