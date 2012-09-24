// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignUpViewModelValidator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The sign up view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation;

    using TdService.Resources;

    /// <summary>
    /// The sign up view model validator.
    /// </summary>
    public class SignUpViewModelValidator : AbstractValidator<SignUpViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpViewModelValidator"/> class.
        /// </summary>
        public SignUpViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(su => su.Email).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.UserEmailRequired)
                .EmailAddress().WithLocalizedMessage(() => ErrorCodeResources.UserEmailInvalid)
                .Length(1, 256).WithLocalizedMessage(() => ErrorCodeResources.UserEmailMaxLength);
            RuleFor(su => su.Password).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.UserPasswordRequired)
                .Length(7, 21).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordLength);
            RuleFor(su => su.PasswordConfirm).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.UserPasswordConfirmRequired)
                .Equal(u => u.Password).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordConfirmNotEqual);
            RuleFor(su => su.FirstName).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.ProfileFirstNameRequired)
                .Length(1, 21).WithLocalizedMessage(() => ErrorCodeResources.ProfileFirstNameMaxLength);
            RuleFor(su => su.LastName).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.ProfileLastNameRequired)
                .Length(1, 21).WithLocalizedMessage(() => ErrorCodeResources.ProfileLastNameMaxLength);
        }
    }
}
