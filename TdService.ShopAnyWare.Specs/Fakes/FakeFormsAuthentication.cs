// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeFormsAuthentication.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the FakeFormsAuthentication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs.Fakes
{
    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// The fake forms authentication.
    /// </summary>
    public class FakeFormsAuthentication : IFormsAuthentication
    {
        /// <summary>
        /// The token.
        /// </summary>
        private string storedToken;

        /// <summary>
        /// Set authentication token.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="persist">
        /// The persist cookie flag.
        /// </param>
        public void SetAuthenticationToken(string token, bool persist)
        {
            this.storedToken = token;
        }

        /// <summary>
        /// Get authentication token.
        /// </summary>
        /// <returns>
        /// Authentication token.
        /// </returns>
        public string GetAuthenticationToken()
        {
            return this.storedToken;
        }

        /// <summary>
        /// Sign out.
        /// </summary>
        public void SignOut()
        {
            this.storedToken = null;
        }
    }
}