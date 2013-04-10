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
        /// The get history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetRecentPackagesResponse"/>.
        /// </returns>
        List<GetRecentPackagesResponse> GetHistory(GetRecentPackagesRequest request);

        /// <summary>
        /// Add new package.
        /// </summary>
        /// <param name="request">
        /// The add package request message.
        /// </param>
        /// <returns>
        /// The <see cref="AddPackageResponse"/>.
        /// </returns>
        AddPackageResponse AddPackage(AddPackageRequest request);

        /// <summary>
        /// Remove package completely.
        /// </summary>
        /// <param name="request">
        /// The remove package request.
        /// </param>
        /// <returns>
        /// The <see cref="RemovePackageResponse"/>.
        /// </returns>
        RemovePackageResponse RemovePackage(RemovePackageRequest request);

        /// <summary>
        /// Changes package delivery address
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangePackageDeliveryAddressResponse ChangePackageDeliveryAddress(ChangePackageDeliveryAddressRequest request);

        /// <summary>
        /// Changes package delivery method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangePackageDeliveryMethodResponse ChangePackageDispatchMethod(ChangePackageDeliveryMethodRequest request);

        /// <summary>
        /// Sets package status to Assemling
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AssemblePackageResponse AssemblePackage(AssemblePackageRequest request);

        /// <summary>
        /// Sets package status to Assembled. Used by operator or admin
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PackageAssembledResponse PackageAssembled(PackageAssembledRequest request);

        /// <summary>
        /// Changes package status to SENT
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SendPackageResponse SendPackage(SendPackageRequest request);

        /// <summary>
        /// Gets packages count (assembling and paid)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetUsersPackagesResponse GetUsersPackages(GetUsersPackagesRequest request);

        /// <summary>
        /// Updates total package size. Available for operator
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdatePackageTotalSizeResponse UpdatePackageTotalSize(UpdatePackageTotalSizeRequest request);

        /// <summary>
        /// Changes Tracking Number For package
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeTrackingNumberResponse ChangePackageTrackingNumber(ChangeTrackingNumberRequest request);
    }
}