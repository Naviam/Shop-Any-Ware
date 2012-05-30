// -----------------------------------------------------------------------
// <copyright file="ILocalAuthenticationService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Authentication
{
    /// <summary>
    /// Interface for local authentication service.
    /// </summary>
    public interface ILocalAuthenticationService
    {
        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Authenticated user.
        /// </returns>
        AuthUser Login(string email, string password);

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Registered user.
        /// </returns>
        AuthUser RegisterUser(string email, string password);
    }
}