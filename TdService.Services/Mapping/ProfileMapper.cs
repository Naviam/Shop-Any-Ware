// -----------------------------------------------------------------------
// <copyright file="ProfileMapper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Membership;

    using Profile = TdService.Model.Membership.Profile;

    /// <summary>
    /// Profile mapper.
    /// </summary>
    public static class ProfileMapper
    {
        /// <summary>
        /// Convert update profile request message to profile domain model.
        /// </summary>
        /// <param name="request">
        /// The update profile request message.
        /// </param>
        /// <returns>
        /// The profile domain model.
        /// </returns>
        public static Profile ConvertToProfile(this UpdateProfileRequest request)
        {
            return Mapper.Map<UpdateProfileRequest, Profile>(request);
        }
    }
}