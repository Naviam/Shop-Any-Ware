// -----------------------------------------------------------------------
// <copyright file="ProfileMapper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Membership;

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
        public static Model.Membership.Profile ConvertToProfile(this UpdateProfileRequest request)
        {
            return Mapper.Map<UpdateProfileRequest, Model.Membership.Profile>(request);
        }

        /// <summary>
        /// The convert to update profile response.
        /// </summary>
        /// <param name="profile">
        /// The profile.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Membership.UpdateProfileResponse.
        /// </returns>
        public static UpdateProfileResponse ConvertToUpdateProfileResponse(this Model.Membership.Profile profile)
        {
            return Mapper.Map<Model.Membership.Profile, UpdateProfileResponse>(profile);
        }

        
    }
}