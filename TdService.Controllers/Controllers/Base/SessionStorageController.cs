using TdService.Infrastructure.Authentication;
using TdService.Infrastructure.SessionStorage;

namespace TdService.UI.Web.Controllers.Base
{
    public class SessionStorageController:BaseAuthController
    {
        /// <summary>
        /// Session storage.
        /// </summary>
        protected readonly ISessionStorage SessionStorage;

        public SessionStorageController(ISessionStorage sessionStorage, IFormsAuthentication formsAuthentication)
            :base(formsAuthentication)
        {
            this.SessionStorage = sessionStorage;
        }
    }
}
