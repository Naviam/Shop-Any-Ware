// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotPasswordViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Forgot Password View Model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    /// <summary>
    /// Forgot Password View Model.
    /// </summary>
    public class ForgotPasswordViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets PasswordSent.
        /// </summary>
        public bool PasswordSent { get; set; }

        /// <summary>
        /// Gets or sets User Not Found.
        /// </summary>
        public bool UserNotFound { get; set; }
    }
}