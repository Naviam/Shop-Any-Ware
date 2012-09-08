// -----------------------------------------------------------------------
// <copyright file="ForgotPasswordView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Forgot Password View Model.
    /// </summary>
    public class ForgotPasswordView : BaseView
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
    }
}