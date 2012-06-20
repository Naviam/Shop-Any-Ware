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
    using System.Resources;
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Email;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
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
        /// Email Service.
        /// </summary>
        private readonly IEmailService emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        /// <param name="emailService">
        /// The email service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public AccountController(
            IMembershipService membershipService,
            IEmailService emailService,
            IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
            this.emailService = emailService;
        }

        /// <summary>
        /// Displays SignIn view. GET: /Account/SignIn
        /// </summary>
        /// <returns>
        /// Returns ActionResult with SignInView.
        /// </returns>
        public ActionResult SignIn()
        {
            var model = new SignInView();
            ViewData.Model = model;
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
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInView request)
        {
            var validateUserRequest = new ValidateUserRequest
                {
                    Email = request.Email,
                    Password = request.Password
                };
            var response = this.membershipService.ValidateUser(validateUserRequest);

            if (response.MessageType != MessageType.Error)
            {
                this.FormsAuthentication.SetAuthenticationToken(request.Email, request.RememberMe);
                return this.RedirectToAction("Dashboard", "Member");
            }

            var model = new SignInView
                {
                    MessageType = response.MessageType.ToString(),
                    Message =
                        response.Message
                        ?? (new ResourceManager(typeof(Resources.ErrorCodeResources))).GetString(response.ErrorCode)
                };
            ViewData.Model = model;
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
            ViewData.Model = new SignUpView();
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
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpView request)
        {
            return this.RedirectToAction("SignIn", "Account");
        }

        /// <summary>
        /// Reset forgotten password form.
        /// </summary>
        /// <returns>
        /// Model with new password.
        /// </returns>
        public ActionResult Forgot()
        {
            ViewData.Model = new ForgotPasswordView();
            return this.View();
        }

        /// <summary>
        /// Reset forgotten password form.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <returns>
        /// Model with new password.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgot(ForgotPasswordView view)
        {
            if (ModelState.IsValid)
            {
                var request = new ChangePasswordLinkRequest { IdentityToken = this.HttpContext.User.Identity.Name };
                var response = this.membershipService.GenerateChangePasswordLink(request);
                this.emailService.SendMail(
                    "noreply@shopanyware.com", 
                    view.Email, 
                    Resources.EmailResources.ResetPasswordSubject, 
                    Resources.EmailResources.ResetPasswordBody);
            }

            return this.View();
        }

        /// <summary>
        /// Logout User.
        /// </summary>
        /// <returns>
        /// Returns Login Form View.
        /// </returns>
        [Authorize]
        public ActionResult SignOut()
        {
            this.FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Home");
        }
    }
}