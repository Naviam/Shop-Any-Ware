// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileViewModelMapping.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The profile view model mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The profile view model mapping.
    /// </summary>
    public static class ProfileViewModelMapping
    {
        /// <summary>
        /// Convert profile view model to update profile request message.
        /// </summary>
        /// <param name="profileView">
        /// The profile view.
        /// </param>
        /// <returns>
        /// Update profile request.
        /// </returns>
        public static UpdateProfileRequest ConvertToUpdateProfileRequest(this ProfileViewModel profileView)
        {
            return Mapper.Map<ProfileViewModel, UpdateProfileRequest>(profileView);
        }

        /// <summary>
        /// The convert to profile view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Account.ProfileViewModel.
        /// </returns>
        public static ProfileViewModel ConvertToProfileViewModel(this UpdateProfileResponse response)
        {
            return Mapper.Map<UpdateProfileResponse, ProfileViewModel>(response);
        }

        /// <summary>
        /// The convert to profile view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Account.ProfileViewModel.
        /// </returns>
        public static ProfileViewModel ConvertToProfileViewModel(this GetProfileResponse response)
        {
            return Mapper.Map<GetProfileResponse, ProfileViewModel>(response);
        }
    }
}
