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
    public class SignUpView
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
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets PasswordConfirm.
        /// </summary>
        [Required]
        public string PasswordConfirm { get; set; }
    }
}