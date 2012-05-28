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
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Role repository.
        /// </summary>
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="roleRepository">
        /// The role repository.
        /// </param>
        public AdminController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
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