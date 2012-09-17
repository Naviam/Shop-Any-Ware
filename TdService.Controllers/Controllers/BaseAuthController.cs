// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseAuthController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the BaseController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// Base contoller contains methods common for all controllers.
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
    }
}