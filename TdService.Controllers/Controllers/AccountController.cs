// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This controller is responsible for authentication and authorization of user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Web.Mvc;
    using System.Xml;
    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.CookieStorage;
    using TdService.Infrastructure.Domain;
    using TdService.Infrastructure.Email;
    using TdService.Model;
    using TdService.Resources;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.Controllers.Base;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// This controller is responsible for authentication and authorization of user.
    /// </summary>
    public class AccountController : BaseAuthController
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
        /// Cookie storage service.
        /// </summary>
        private readonly ICookieStorageService cookieStorageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        /// <param name="emailService">
        /// The email service.
        /// </param>
        /// <param name="cookieStorageService">
        /// The cookie Storage Service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public AccountController(
            IMembershipService membershipService,
            IEmailService emailService,
            ICookieStorageService cookieStorageService,
            IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
            this.emailService = emailService;
            this.cookieStorageService = cookieStorageService;
        }

        /// <summary>
        /// Displays SignIn view. GET: /Account/SignIn
        /// </summary>
        /// <returns>
        /// Returns ActionResult with SignInView.
        /// </returns>
        public ActionResult SignIn()
        {
            var model = new MainViewModel { SignInViewModel = new SignInViewModel() };
            var signInViewModel = model.SignInViewModel;
            this.SetCredentialsFromCookie(ref signInViewModel);
            model.SignInViewModel = signInViewModel;
            this.ViewData.Model = model;
            return this.View("SignIn");
        }

        /// <summary>
        /// The sign in.
        /// </summary>
        /// <summary>
        /// Defines a POST interface for submiting the SignIn form.
        /// </summary>
        /// <param name="model">
        /// Sign In Request object with username, password and remember me fields. The model.
        /// </param>
        /// <returns>
        /// Redirect user to the home page of authenticated users.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn([Bind(Prefix = "SignInViewModel")]SignInViewModel model)
        {
            var result = new SignInViewModel();
            var validator = new SignInViewModelValidator();
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {
                var validateUserRequest = model.ConvertToSignInRequest();
                var response = this.membershipService.SignIn(validateUserRequest);
                result = response.ConvertToSignInViewModel();

                if (response.MessageType == MessageType.Success)
                {
                    this.FormsAuthentication.SetAuthenticationToken(model.Email, false);
                    this.SaveCredentialsToCookie(model);
                    var userRolesResponse = this.membershipService.GetUserRoles(new GetUserRolesRequest { IdentityToken = model.Email });
                    var roles = userRolesResponse.ConvertToRoleViewModelCollection();
                    if (roles.Exists(r => r.Name == StandardRole.Shopper.ToString()))
                    {
                        return this.RedirectToAction("Dashboard", "Member");
                    }

                    if (roles.Exists(r => r.Name == StandardRole.Admin.ToString()))
                    {
                        return this.RedirectToAction("Dashboard", "Admin");
                    }

                    // for consultant and operator
                    return this.RedirectToAction("Dashboard", "Admin");
                }

                this.ModelState.AddModelError("SignInViewModel.Email", result.Message);
            }
            else
            {
                result.MessageType = MessageType.Warning.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.CustomState.ToString()));
                }
            }

            if (string.IsNullOrWhiteSpace(result.Email))
            {
                result.Email = model.Email;
            }

            return this.View("SignIn", new MainViewModel { SignInViewModel = result });
        }

        /// <summary>
        /// Displays Registration Form.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult SignUp()
        {
            var model = new MainViewModel { SignUpViewModel = new SignUpViewModel() };
            return this.View("SignUp", model);
        }

        /// <summary>
        /// Process registration form data and create user's account
        /// </summary>
        /// <param name="model">
        /// The view model.
        /// </param>
        /// <returns>
        /// Redirects user to Sign In form in case of success.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Prefix = "SignUpViewModel")]SignUpViewModel model)
        {
            var result = new SignUpViewModel();
            var validator = new SignUpViewModelValidator();
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {
                var request = new SignUpRequest
                {
                    IdentityToken = null,
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var response = this.membershipService.SignUpShopper(request);
                result = response.ConvertToSignUpViewModel();

                if (result.BrokenRules != null && result.BrokenRules.Any())
                {
                    foreach (var rule in result.BrokenRules)
                    {
                        ModelState.AddModelError(string.Concat("SignUpViewModel.", rule.Property), rule.Rule);
                    }
                }
                else
                {
                    this.FormsAuthentication.SetAuthenticationToken(model.Email, false);
                    return this.RedirectToAction("Welcome", "Member");
                }
            }
            else
            {
                result.MessageType = MessageType.Warning.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.CustomState.ToString()));
                }
            }

            if (string.IsNullOrWhiteSpace(result.Email))
            {
                result.Email = model.Email;
            }

            if (string.IsNullOrWhiteSpace(result.FirstName))
            {
                result.FirstName = model.FirstName;
            }

            if (string.IsNullOrWhiteSpace(result.LastName))
            {
                result.LastName = model.LastName;
            }

            this.ViewData.Model = new MainViewModel { SignUpViewModel = result };
            return this.View("SignUp");
        }

        /// <summary>
        /// Check if email exists in database.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// View with
        /// </returns>
        [HttpPost]
        public ActionResult VerifyEmail(string email)
        {
            var result = new VerifyEmailViewModel();

            var response = this.membershipService.GetProfile(new GetProfileRequest { IdentityToken = email });
            if (response.Id == 0)
            {
                result.MessageType = MessageType.Success.ToString();
                result.Message = CommonResources.VerifyEmailOkMessage;
            }
            else
            {
                result.EmailExists = true;
                result.MessageType = MessageType.Warning.ToString();
                result.Message = CommonResources.VerifyEmailExistsMessage;
            }

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Reset forgotten password form.
        /// </summary>
        /// <returns>
        /// Model with new password.
        /// </returns>
        public ActionResult Forgot()
        {
            this.ViewData.Model = new ForgotPasswordViewModel();
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
        public ActionResult Forgot(ForgotPasswordViewModel view)
        {
            if (this.ModelState.IsValid)
            {
                var request = new ChangePasswordLinkRequest { IdentityToken = view.Email };
                this.membershipService.GenerateChangePasswordLink(request);
                this.emailService.SendMail(
                    EmailResources.EmailActivationFrom,
                    view.Email,
                    EmailResources.ResetPasswordSubject,
                    EmailResources.ResetPasswordBody);
            }

            return this.View(view);
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
            return this.RedirectToAction("SignIn", "Account");
        }

        /// <summary>
        /// The activate email.
        /// </summary>
        /// <param name="uid">
        /// The user id.
        /// </param>
        /// <param name="hash">
        /// The hash.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ActivateEmail(int uid, Guid hash)
        {
            var request = new ActivateUserEmailRequest { ActivationCode = hash, UserId = uid };
            var response = this.membershipService.ActivateEmail(request);
            return this.View(new ActivateEmailViewModel { ActivateionResult = response.Message });
        }

        /// <summary>
        /// Save credentials to cookie.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        private void SaveCredentialsToCookie(SignInViewModel view)
        {
            if (view.RememberMe)
            {
                var values = new NameValueCollection(3);
                values["Email"] = view.Email;
                ////values["Password"] = view.Password;
                values["RememberMe"] = view.RememberMe ? "yes" : "no";
                this.cookieStorageService.SaveCollection(
                    "shopanyware_login", values, DateTime.UtcNow.AddYears(20));
            }
            else
            {
                var values = new NameValueCollection(3);
                values["Email"] = string.Empty;
                ////values["Password"] = string.Empty;
                values["RememberMe"] = string.Empty;
                this.cookieStorageService.SaveCollection(
                    "shopanyware_login", values, DateTime.UtcNow.AddDays(-2));
            }
        }

        /// <summary>
        /// Set credentials from cookie to sign in view.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        private void SetCredentialsFromCookie(ref SignInViewModel view)
        {
            var values = this.cookieStorageService.RetrieveCollection("shopanyware_login");
            if (values != null)
            {
                view.Email = values["Email"];
                ////view.Password = values["Password"];
                view.RememberMe = values["RememberMe"] == "yes";
            }
        }
    }
}