// -----------------------------------------------------------------------
// <copyright file="AuthUser.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Authentication
{
    /// <summary>
    /// This class describes user of the web site.
    /// </summary>
    public class AuthUser
    {
        /// <summary>
        /// Gets or sets AuthenticationToken.
        /// </summary>
        public string AuthenticationToken { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user is authenticated.
        /// </summary>
        public bool IsAuthenticated { get; set; }
    }
}