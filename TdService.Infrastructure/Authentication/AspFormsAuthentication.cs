// -----------------------------------------------------------------------
// <copyright file="AspFormsAuthentication.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Authentication
{
    using System.Web;
    using System.Web.Security;

    /// <summary>
    /// Asp net forms authentication.
    /// </summary>
    public class AspFormsAuthentication : IFormsAuthentication
    {
        /// <summary>
        /// Set authentication token.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="persist">
        /// The persist cookie boolean value.
        /// </param>
        public void SetAuthenticationToken(string token, bool persist)
        {
            FormsAuthentication.SetAuthCookie(token, persist);
        }

        /// <summary>
        /// Get authentication token.
        /// </summary>
        /// <returns>
        /// Authentication token.
        /// </returns>
        public string GetAuthenticationToken()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        /// <summary>
        /// Sign out.
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}