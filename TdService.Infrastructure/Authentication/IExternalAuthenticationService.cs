// -----------------------------------------------------------------------
// <copyright file="IExternalAuthenticationService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Authentication
{
    /// <summary>
    /// Interface for external authentication service.
    /// </summary>
    public interface IExternalAuthenticationService
    {
        /// <summary>
        /// Get user details from external authentication service.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// User details.
        /// </returns>
        AuthUser GetUserDetailsFrom(string token);
    }
}