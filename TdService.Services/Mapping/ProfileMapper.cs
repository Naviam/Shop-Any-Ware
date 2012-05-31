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
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <returns>
        /// </returns>
        public static ProfileView ConvertToProfileView(this Profile profile)
        {
            return Mapper.Map<Profile, ProfileView>(profile);
        }
    }
}