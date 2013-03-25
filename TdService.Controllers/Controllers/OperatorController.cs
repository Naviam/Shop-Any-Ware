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
    using TdService.UI.Web.Controllers.Base;

    /// <summary>
    /// The operator controller.
    /// </summary>
    public class OperatorController : BaseAuthController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public OperatorController(IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
        }

        /// <summary>
        /// The dashboard.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Operator")]
        public ActionResult Dashboard()
        {
            return this.View();
        }
    }
}
