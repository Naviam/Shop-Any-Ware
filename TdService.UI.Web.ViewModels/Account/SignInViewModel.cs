﻿// -----------------------------------------------------------------------
// <copyright file="SignInViewModel.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation.Attributes;

    /// <summary>
    /// This class describes the view model for sign in page.
    /// </summary>
    [Validator(typeof(SignInViewModelValidator))]
    public class SignInViewModel : ViewModelBase
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
        /// Gets or sets a value indicating whether user cookies should be remembered.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}