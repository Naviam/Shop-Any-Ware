// -----------------------------------------------------------------------
// <copyright file="SignInRequest.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Messaging.Account
{
    /// <summary>
    /// This class describes request parameters for sign in action.
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
