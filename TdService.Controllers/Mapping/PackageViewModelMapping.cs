// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageViewModelMapping.cs" company="Naviam">
//   Vitali Hatalski. 2013
// </copyright>
// <summary>
//   The package view model mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Package;
    using TdService.UI.Web.ViewModels.Package;

    /// <summary>
    /// The package view model mapping.
    /// </summary>
    public static class PackageViewModelMapping
    {
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
        /// The list of get recent packages responses.
        /// </param>
        /// <returns>
        /// The list of package view models.
        /// </returns>
        public static List<PackageViewModel> ConvertToPackageViewModelCollection(this List<GetRecentPackagesResponse> responses)
        {
            return Mapper.Map<List<GetRecentPackagesResponse>, List<PackageViewModel>>(responses);
        }

        /// <summary>
        /// The convert to package view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageViewModel"/>.
        /// </returns>
        public static PackageViewModel ConvertToPackageViewModel(this AssemblePackageResponse response)
        {
            return Mapper.Map<AssemblePackageResponse, PackageViewModel>(response);
        }

        /// <summary>
        /// The convert to package view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageViewModel"/>.
        /// </returns>
        public static PackageViewModel ConvertToPackageViewModel(this PackageAssembledResponse response)
        {
            return Mapper.Map<PackageAssembledResponse, PackageViewModel>(response);
        }

        /// <summary>
        /// The convert to package view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="PayForPackageViewModel"/>.
        /// </returns>
        public static PayForPackageViewModel ConvertToPackageViewModel(this PayForPackageResponse response)
        {
            return Mapper.Map<PayForPackageResponse, PayForPackageViewModel>(response);
        }

        /// <summary>
        /// The convert to package view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageViewModel"/>.
        /// </returns>
        public static PackageViewModel ConvertToPackageViewModel(this SendPackageResponse response)
        {
            return Mapper.Map<SendPackageResponse, PackageViewModel>(response);
        }

        /// <summary>
        /// The convert to users packages view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="UsersPackagesViewModel"/>.
        /// </returns>
        public static UsersPackagesViewModel ConvertToUsersPackagesViewModel(this GetUsersPackagesResponse response)
        {
            return Mapper.Map<GetUsersPackagesResponse, UsersPackagesViewModel>(response);
        }

        /// <summary>
        /// The convert to update package total size request.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="UpdatePackageTotalSizeRequest"/>.
        /// </returns>
        public static UpdatePackageTotalSizeRequest ConvertToUpdatePackageTotalSizeRequest(this PackageSizePopupViewModel model)
        {
            return Mapper.Map<PackageSizePopupViewModel, UpdatePackageTotalSizeRequest>(model);
        }

        /// <summary>
        /// The convert to users packages view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="PackageViewModel"/>.
        /// </returns>
        public static PackageViewModel ConvertToUsersPackagesViewModel(this UpdatePackageTotalSizeResponse response)
        {
            return Mapper.Map<UpdatePackageTotalSizeResponse, PackageViewModel>(response);
        }
    }
}