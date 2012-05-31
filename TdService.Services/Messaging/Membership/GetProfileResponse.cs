// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetProfileResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the get profile request object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Get profile response object.
    /// </summary>
    public class GetProfileResponse
    {
        /// <summary>
        /// Gets or sets Profile.
        /// </summary>
        public ProfileView ProfileView { get; set; }
    }
}