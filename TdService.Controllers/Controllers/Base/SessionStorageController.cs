// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionStorageController.cs" company="Naviam">
//   Vitali Hatalski. 2013
// </copyright>
// <summary>
//   The session storage controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers.Base
{
    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.SessionStorage;

    /// <summary>
    /// The session storage controller.
    /// </summary>
    public class SessionStorageController : BaseAuthController
    {
        /// <summary>
        /// Session storage.
        /// </summary>
        protected readonly ISessionStorage SessionStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStorageController"/> class.
        /// </summary>
        /// <param name="sessionStorage">
        /// The session storage.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public SessionStorageController(ISessionStorage sessionStorage, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.SessionStorage = sessionStorage;
        }
    }
}
