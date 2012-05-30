// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterUserResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the RegisterUserResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// Register user response for service.
    /// </summary>
    public class RegisterUserResponse
    {
        /// <summary>
        /// Gets or sets IdentityToken.
        /// </summary>
        public string IdentityToken { get; set; }
    }
}