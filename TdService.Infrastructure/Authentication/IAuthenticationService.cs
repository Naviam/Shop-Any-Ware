// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthenticationService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IAuthenticationService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Authentication
{
    /// <summary>
    /// Interface for the Membership API.
    /// </summary>
    public interface IAuthenticationService
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
        void Login(string email, string password);

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        void RegisterUser(string email, string password);
    }
}