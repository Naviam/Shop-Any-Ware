// -----------------------------------------------------------------------
// <copyright file="SignUpRequest.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.AppService
{
    /// <summary>
    /// This class describes request parameters for sign up action.
    /// </summary>
    public class SignUpRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Password Confirmation.
        /// </summary>
        public string PasswordConfirm { get; set; }
    }
}
