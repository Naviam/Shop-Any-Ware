// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This controller is responsible for authentication and authorization of user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Model.Membership;
    using TdService.Services;

    /// <summary>
    /// This controller is responsible for authentication and authorization of user.
    /// </summary>
    public class AccountController : BaseController
    {
        /// <summary>
        /// User repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Form authentication.
        /// </summary>
        private readonly IFormsAuthentication formsAuthentication;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="formsAuthentication">
        /// The form Authentication.
        /// </param>
        public AccountController(IUserRepository userRepository, IFormsAuthentication formsAuthentication)
        {
            this.userRepository = userRepository;
            this.formsAuthentication = formsAuthentication;
        }

        /// <summary>
        /// Displays SignIn view. GET: /Account/SignIn
        /// </summary>
        /// <returns>
        /// Returns ActionResult with SignInView.
        /// </returns>
        public ActionResult SignIn()
        {
            return this.View();
        }

        /// <summary>
        /// Defines a POST interface for submiting the SignIn form.
        /// </summary>
        /// <param name="request">
        /// Sign In Request object with username, password and remember me fields.
        /// </param>
        /// <returns>
        /// Redirect user to the home page of authenticated users.
        /// </returns>
        [HttpPost]
        public ActionResult SignIn(SignInRequest request)
        {
            var isValid = this.userRepository.ValidateUser(request.Email, request.Password);

            if (isValid)
            {
                this.formsAuthentication.SetAuthenticationToken(request.Email);
                return this.RedirectToAction("Dashboard", "Member");
            }

            return this.View();
        }

        /// <summary>
        /// Displays Registration Form.
        /// </summary>
        /// <returns>
        /// Returns Action Result with SignUpView model.
        /// </returns>
        public ActionResult SignUp()
        {
            return this.View();
        }

        /// <summary>
        /// Process registration form data and create user's account
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Redirects user to Sign In form in case of success.
        /// </returns>
        [HttpPost]
        public ActionResult SignUp(SignUpRequest request)
        {
            return this.RedirectToAction("SignIn");
        }

        /// <summary>
        /// Logout User.
        /// </summary>
        /// <returns>
        /// Returns Login Form View.
        /// </returns>
        public ActionResult SignOut()
        {
            this.formsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
