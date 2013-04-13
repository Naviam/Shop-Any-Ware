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
        /// The change package delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ChangePackageDeliveryAddressResponse"/>.
        /// </returns>
        ChangePackageDeliveryAddressResponse ChangePackageDeliveryAddress(ChangePackageDeliveryAddressRequest request);

        /// <summary>
        /// The change package dispatch method.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ChangePackageDeliveryMethodResponse"/>.
        /// </returns>
        ChangePackageDeliveryMethodResponse ChangePackageDispatchMethod(ChangePackageDeliveryMethodRequest request);

        /// <summary>
        /// The assemble package.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="AssemblePackageResponse"/>.
        /// </returns>
        AssemblePackageResponse AssemblePackage(AssemblePackageRequest request);

        /// <summary>
        /// The package assembled.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="PackageAssembledResponse"/>.
        /// </returns>
        PackageAssembledResponse PackageAssembled(PackageAssembledRequest request);

        /// <summary>
        /// The send package.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SendPackageResponse"/>.
        /// </returns>
        SendPackageResponse SendPackage(SendPackageRequest request);

        /// <summary>
        /// The get users packages.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="GetUsersPackagesResponse"/>.
        /// </returns>
        GetUsersPackagesResponse GetUsersPackages(GetUsersPackagesRequest request);

        /// <summary>
        /// The update package total size.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="UpdatePackageTotalSizeResponse"/>.
        /// </returns>
        UpdatePackageTotalSizeResponse UpdatePackageTotalSize(UpdatePackageTotalSizeRequest request);

        /// <summary>
        /// The change package tracking number.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ChangeTrackingNumberResponse"/>.
        /// </returns>
        ChangeTrackingNumberResponse ChangePackageTrackingNumber(ChangeTrackingNumberRequest request);
    }
}