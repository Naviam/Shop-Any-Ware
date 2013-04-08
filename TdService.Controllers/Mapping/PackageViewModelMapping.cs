using System.Collections.Generic;

namespace TdService.UI.Web.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Package;
    using TdService.UI.Web.ViewModels.Package;

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
        /// The list of get recent packags responses.
        /// </param>
        /// <returns>
        /// The list of package view models.
        /// </returns>
        public static List<PackageViewModel> ConvertToPackageViewModelCollection(this List<GetRecentPackagesResponse> responses)
        {
            return Mapper.Map<List<GetRecentPackagesResponse>, List<PackageViewModel>>(responses);
        }


        public static PackageViewModel ConvertToPackageViewModel(this AssemblePackageResponse response)
        {
            return Mapper.Map<AssemblePackageResponse, PackageViewModel>(response);
        }

        public static PackageViewModel ConvertToPackageViewModel(this PackageAssembledResponse response)
        {
            return Mapper.Map<PackageAssembledResponse, PackageViewModel>(response);
        }

        public static PayForPackageViewModel ConvertToPackageViewModel(this PayForPackageResponse response)
        {
            return Mapper.Map<PayForPackageResponse, PayForPackageViewModel>(response);
        }

        public static PackageViewModel ConvertToPackageViewModel(this SendPackageResponse response)
        {
            return Mapper.Map<SendPackageResponse, PackageViewModel>(response);
        }

        public static UsersPackagesViewModel ConvertToUsersPackagesViewModel(this GetUsersPackagesResponse response)
        {
            return Mapper.Map<GetUsersPackagesResponse, UsersPackagesViewModel>(response);
        }

        public static UpdatePackageTotalSizeRequest ConvertToUpdatePackageTotalSizeRequest(this PackageSizePopupViewModel model)
        {
            return Mapper.Map<PackageSizePopupViewModel, UpdatePackageTotalSizeRequest>(model);
        }

        public static PackageViewModel ConvertToUsersPackagesViewModel(this UpdatePackageTotalSizeResponse response)
        {
            return Mapper.Map<UpdatePackageTotalSizeResponse, PackageViewModel>(response);
        }
    }
}