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
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Account;

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
            var model = new SignInViewModel();
            this.SetCredentialsFromCookie(ref model);
            this.ViewData.Model = model;
            return this.View();
        }

        /// <summary>
        /// Defines a POST interface for submiting the SignIn form.
        /// </summary>
        /// <param name="model">
        /// Sign In Request object with username, password and remember me fields.
        /// </param>
        /// <returns>
        /// Redirect user to the home page of authenticated users.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken(Salt = "signin")]
        public ActionResult SignIn(SignInViewModel model)
        {
            var result = new SignInViewModel();
            var validator = new SignInViewModelValidator();
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {
                var validateUserRequest = model.ConvertToSignInRequest();
                var response = this.membershipService.SignIn(validateUserRequest);
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

                    return this.RedirectToAction("Dashboard", "Admin");
                }

                result = response.ConvertToSignInViewModel();
            }
            else
            {
                result.MessageType = MessageType.Warning.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.ErrorMessage));
                }
            }

            if (string.IsNullOrWhiteSpace(result.Email))
            {
                result.Email = model.Email;
            }

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Displays Registration Form.
        /// </summary>
        /// <returns>
        /// Returns Action Result with SignUpView model.
        /// </returns>
        public ActionResult SignUp()
        {
            this.ViewData.Model = new SignUpViewModel();
            return this.View();
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
        [ValidateAntiForgeryToken(Salt = "signup")]
        public ActionResult SignUp(SignUpViewModel model)
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
            }
            else
            {
                result.MessageType = MessageType.Warning.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.ErrorMessage));
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

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
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
            var response = this.membershipService.GetUser(new GetUserRequest { IdentityToken = email });
            if (response.User != null)
            {
                response.Message = Resources.Views.AccountViewResources.SignUpEmailOk;
            }

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response
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