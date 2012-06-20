// -----------------------------------------------------------------------
// <copyright file="FakeFormsAuthentication.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Mocks
{
    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// Fake forms authentication for testing purpose.
    /// </summary>
    public class FakeFormsAuthentication : IFormsAuthentication
    {
        /// <summary>
        /// Gets or sets Token.
        /// </summary>
        public string Token { get; set; }

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
            this.Token = token;
        }

        /// <summary>
        /// Get authentication token.
        /// </summary>
        /// <returns>
        /// Authentication token.
        /// </returns>
        public string GetAuthenticationToken()
        {
            return this.Token;
        }

        /// <summary>
        /// Sign out.
        /// </summary>
        public void SignOut()
        {
            this.Token = null;
        }
    }
}