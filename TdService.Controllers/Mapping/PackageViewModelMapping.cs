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
    }
}