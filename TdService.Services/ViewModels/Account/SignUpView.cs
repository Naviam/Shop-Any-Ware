// -----------------------------------------------------------------------
// <copyright file="SignUpView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class describes the view model for sign up page.
    /// </summary>
    public class SignUpView : BaseView
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(256, ErrorMessageResourceName = "MaxLengthEmail", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [RegularExpression(@"^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$",
            ErrorMessageResourceName = "InvalidEmail",
            ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredPassword", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(21, MinimumLength = 7, ErrorMessageResourceName = "MaxLengthPassword", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Password Confirm.
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredPasswordConfirmation", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(21, MinimumLength = 7, ErrorMessageResourceName = "MaxLengthPassword", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string PasswordConfirm { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredFirstName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(64, ErrorMessageResourceName = "MaxLengthFirstName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredLastName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(64, ErrorMessageResourceName = "MaxLengthLastName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string LastName { get; set; }
    }
}