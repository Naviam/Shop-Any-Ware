// -----------------------------------------------------------------------
// <copyright file="AdminController.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Model.Membership;

    /// <summary>
    /// This controller is responsible for administrative tasks.
    /// </summary>
    public class AdminAuthController : BaseAuthController
    {
        /// <summary>
        /// User repository.
        /// </summary>
        private readonly IMembershipRepository membershipRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminAuthController"/> class.
        /// </summary>
        /// <param name="membershipRepository">
        /// The membership Repository.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms Authentication.
        /// </param>
        public AdminAuthController(IMembershipRepository membershipRepository, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.membershipRepository = membershipRepository;
        }

        /// <summary>
        /// Testing the new interface.
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        public ActionResult Dashboard()
        {
            return this.View();
        }
    }
}