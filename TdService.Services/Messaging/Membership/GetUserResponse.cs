// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUserResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the GetUserResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    using TdService.Model.Membership;

    /// <summary>
    /// Get user response object.
    /// </summary>
    public class GetUserResponse
    {
        /// <summary>
        /// Gets or sets User.
        /// </summary>
        public User User { get; set; }
    }
}