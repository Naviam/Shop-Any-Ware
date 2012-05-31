// -----------------------------------------------------------------------
// <copyright file="AdminController.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Model.Membership;

    /// <summary>
    /// This controller is responsible for administrative tasks.
    /// </summary>
    public class AdminController : BaseController
    {
        /// <summary>
        /// User repository.
        /// </summary>
        private readonly IMembershipRepository membershipRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="membershipRepository">
        /// The membership Repository.
        /// </param>
        public AdminController(IMembershipRepository membershipRepository)
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