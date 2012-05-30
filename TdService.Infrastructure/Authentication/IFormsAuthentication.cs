// -----------------------------------------------------------------------
// <copyright file="IFormsAuthentication.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Authentication
{
    /// <summary>
    /// This interface hides the realization of forms authentication.
    /// </summary>
    public interface IFormsAuthentication
    {
        /// <summary>
        /// Set authentication token.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="persist">
        /// The persist cookie flag.
        /// </param>
        void SetAuthenticationToken(string token, bool persist);

        /// <summary>
        /// Get authentication token.
        /// </summary>
        /// <returns>
        /// Authentication token.
        /// </returns>
        string GetAuthenticationToken();

        /// <summary>
        /// Sign out.
        /// </summary>
        void SignOut();
    }
}