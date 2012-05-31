// -----------------------------------------------------------------------
// <copyright file="ProfileMapper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using AutoMapper;

    using TdService.Services.ViewModels.Account;

    using Profile = TdService.Model.Membership.Profile;

    /// <summary>
    /// Profile mapper.
    /// </summary>
    public static class ProfileMapper
    {
        /// <summary>
        /// Convert profile view to profile domain object.
        /// </summary>
        /// <param name="profileView">
        /// The profile view.
        /// </param>
        /// <returns>
        /// Profile object.
        /// </returns>
        public static Profile ConvertToProfile(this ProfileView profileView)
        {
            return Mapper.Map<ProfileView, Profile>(profileView);
        }
    }
}