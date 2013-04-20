// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewPasswordViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   Defines the NewPasswordViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using System;

    using FluentValidation.Attributes;

    /// <summary>
    /// The new password view model.
    /// </summary>
    [Validator(typeof(NewPasswordViewModelValidator))]
    public class NewPasswordViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the password reset key.
        /// </summary>
        public Guid PwdResetKey { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
