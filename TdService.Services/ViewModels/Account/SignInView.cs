// -----------------------------------------------------------------------
// <copyright file="SignInView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This class describes the view model for sign in page.
    /// </summary>
    public class SignInView
    {
        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user cookies should be remembered.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}