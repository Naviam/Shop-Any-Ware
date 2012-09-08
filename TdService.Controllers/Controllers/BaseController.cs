// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the BaseController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// Base contoller contains methods common for all controllers.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Authentication service.
        /// </summary>
        protected readonly IFormsAuthentication FormsAuthentication;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication service.
        /// </param>
        public BaseController(IFormsAuthentication formsAuthentication)
        {
            this.FormsAuthentication = formsAuthentication;
        }
    }
}