// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BalanceController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the BalanceController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// This controller contains methods to work with balance.
    /// </summary>
    public class BalanceController : BaseAuthController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public BalanceController(IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
        }
    }
}
