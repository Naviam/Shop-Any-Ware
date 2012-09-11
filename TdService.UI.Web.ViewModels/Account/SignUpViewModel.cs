// -----------------------------------------------------------------------
// <copyright file="SignUpViewModel.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class describes the view model for sign up page.
    /// </summary>
    public class SignUpViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Required(ErrorMessageResourceName = "UserEmailRequired", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(256, ErrorMessageResourceName = "UserEmailMaxLength", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [RegularExpression(@"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$",
            ErrorMessageResourceName = "UserEmailInvalid",
            ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [Required(ErrorMessageResourceName = "UserPasswordRequired", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(21, MinimumLength = 7, ErrorMessageResourceName = "UserPasswordMaxLength", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Password Confirm.
        /// </summary>
        [Required(ErrorMessageResourceName = "UserPasswordConfirmRequired", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [Compare("Password", ErrorMessageResourceName = "UserPasswordConfirmNotEqual", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string PasswordConfirm { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        [Required(ErrorMessageResourceName = "ProfileFirstNameRequired", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(64, ErrorMessageResourceName = "ProfileFirstNameMaxLength", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        [Required(ErrorMessageResourceName = "ProfileLastNameRequired", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(64, ErrorMessageResourceName = "ProfileLastNameMaxLength", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
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