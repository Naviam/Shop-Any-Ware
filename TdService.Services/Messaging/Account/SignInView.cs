// -----------------------------------------------------------------------
// <copyright file="SignInView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Messaging.Account
{
    /// <summary>
    /// This is a view object for UI.
    /// </summary>
    public class SignInView
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user cookies should be persistent.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
