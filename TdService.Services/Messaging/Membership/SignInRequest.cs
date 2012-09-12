// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Validate user request object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// Validate user request object.
    /// </summary>
    public class SignInRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }
    }
}