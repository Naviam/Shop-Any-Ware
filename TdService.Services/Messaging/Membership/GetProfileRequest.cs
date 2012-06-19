// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetProfileRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the get profile request object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// Get profile request object.
    /// </summary>
    public class GetProfileRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }
    }
}