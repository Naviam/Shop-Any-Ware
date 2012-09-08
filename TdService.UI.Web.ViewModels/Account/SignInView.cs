// -----------------------------------------------------------------------
// <copyright file="SignInView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class describes the view model for sign in page.
    /// </summary>
    public class SignInView : BaseView
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
        [StringLength(21, ErrorMessageResourceName = "MaxLengthPassword", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user cookies should be remembered.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}