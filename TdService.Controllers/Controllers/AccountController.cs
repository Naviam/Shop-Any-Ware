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
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// This controller is responsible for authentication and authorization of user.
    /// </summary>
    public class AccountController : BaseController
    {
        /// <summary>
        /// Membership repository.
        /// </summary>
        private readonly IMembershipService membershipService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public AccountController(IMembershipService membershipService, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
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
        public ActionResult SignIn(SignInView request)
        {
            // var user = new AuthUser { IsAuthenticated = false };
            var validateUserRequest = new ValidateUserRequest { Email = request.Email, Password = request.Password };
            var isValid = this.membershipService.ValidateUser(validateUserRequest);

            if (isValid)
            {
                // var getUserRequest = new GetUserRequest { Email = request.Email };
                // var validatedUser = this.membershipService.GetUser(getUserRequest);
                // user.AuthenticationToken = validatedUser.Id.ToString(CultureInfo.InvariantCulture);
                // user.Email = validatedUser.Email;
                // user.IsAuthenticated = true;
                this.FormsAuthentication.SetAuthenticationToken(request.Email, request.RememberMe);
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
        public ActionResult SignUp(SignUpView request)
        {
            return this.RedirectToAction("SignIn", "Account");
        }

        /// <summary>
        /// Remind forgotten password or email form.
        /// </summary>
        /// <returns>
        /// Forgot email or password page.
        /// </returns>
        public ActionResult Forgot()
        {
            return this.View();
        }

        /// <summary>
        /// Logout User.
        /// </summary>
        /// <returns>
        /// Returns Login Form View.
        /// </returns>
        public ActionResult SignOut()
        {
            this.FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }
    }
}