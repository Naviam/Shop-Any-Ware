// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseAuthController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the BaseController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers.Base
{
    using System;
    using System.Linq;
    using System.Web.Security;

    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// Base controller contains methods common for all controllers.
    /// </summary>
    public class BaseAuthController : BaseController
    {
        /// <summary>
        /// Authentication service.
        /// </summary>
        protected readonly IFormsAuthentication FormsAuthentication;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAuthController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication service.
        /// </param>
        public BaseAuthController(IFormsAuthentication formsAuthentication)
        {
            this.FormsAuthentication = formsAuthentication;
        }

        /// <summary>
        /// The ensure user email is not changed.
        /// </summary>
        /// <param name="userEmail">
        /// The user email.
        /// </param>
        /// <exception cref="Exception">
        /// Access violation.
        /// </exception>
        protected void EnsureUserEmailIsNotChanged(string userEmail)
        {
            if (Roles.Enabled && !Roles.GetRolesForUser().Contains("Operator")
                && !userEmail.Equals(this.FormsAuthentication.GetAuthenticationToken()))
            {
                throw new Exception("Access violation");
            }
        }
    }
}