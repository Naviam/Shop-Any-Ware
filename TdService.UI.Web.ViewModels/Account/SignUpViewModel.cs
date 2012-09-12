// -----------------------------------------------------------------------
// <copyright file="SignUpViewModel.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    /// <summary>
    /// This class describes the view model for sign up page.
    /// </summary>
    public class SignUpViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Password Confirm.
        /// </summary>
        public string PasswordConfirm { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the activation code.
        /// </summary>
        public string ActivationCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether activated.
        /// </summary>
        public bool Activated { get; set; }
    }
}