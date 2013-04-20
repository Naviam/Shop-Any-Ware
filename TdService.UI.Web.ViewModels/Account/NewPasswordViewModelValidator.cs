// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewPasswordViewModelValidator.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The new password view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation;

    using TdService.Resources;

    /// <summary>
    /// The new password view model validator.
    /// </summary>
    public class NewPasswordViewModelValidator : AbstractValidator<NewPasswordViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewPasswordViewModelValidator"/> class.
        /// </summary>
        public NewPasswordViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(np => np.Password).NotEmpty().WithMessage(ErrorCodeResources.UserPasswordRequired).Length(7, 21).WithMessage(ErrorCodeResources.UserPasswordLength).Equal(
                np => np.ConfirmPassword).WithMessage(ErrorCodeResources.UserPasswordConfirmNotEqual);
        }
    }
}
