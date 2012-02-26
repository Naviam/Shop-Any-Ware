// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This controller is responsible for authentication and authorization of user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Security;

namespace TdService.Web.Controllers
{
    using System.Web.Mvc;
    using AppService;

    /// <summary>
    /// This controller is responsible for authentication and authorization of user.
    /// </summary>
    public class AccountController : BaseController
    {
        /// <summary>
        /// Displays SignIn view. GET: /Account/SignIn
        /// </summary>
        /// <returns>
        /// Returns ActionResult with SignInView.
        /// </returns>
        public ActionResult SignIn()
        {
            return View();
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
            FormsAuthentication.RedirectFromLoginPage("demo", true);

            return View();

            // return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Displays Registration Form.
        /// </summary>
        /// <returns>
        /// Returns Action Result with SignUpView model.
        /// </returns>
        public ActionResult SignUp()
        {
            return View();
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
            return RedirectToAction("SignIn");
        }

        /// <summary>
        /// Logout User.
        /// </summary>
        /// <returns>
        /// Returns Login Form View.
        /// </returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
