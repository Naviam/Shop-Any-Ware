// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatorController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The operator controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// The operator controller.
    /// </summary>
    public class OperatorAuthController : BaseAuthController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorAuthController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public OperatorAuthController(IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        [Authorize(Roles = "Operator")]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
