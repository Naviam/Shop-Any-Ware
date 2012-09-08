namespace TdService.UI.Web.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Account;

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
        public static UpdateProfileRequest ConvertToProfile(this ProfileViewModel profileView)
        {
            return Mapper.Map<ProfileViewModel, UpdateProfileRequest>(profileView);
        }
    }
}
