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

    using TdService.Infrastructure.Domain;
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

            RuleFor(su => su.Email)
                .NotEmpty().WithState(e => ErrorCode.UserEmailRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserEmailRequired)
                .EmailAddress().WithState(e => ErrorCode.UserEmailInvalid.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserEmailInvalid)
                .Length(1, 256).WithState(e => ErrorCode.UserEmailMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserEmailMaxLength);
            RuleFor(su => su.Password)
                .NotEmpty().WithState(e => ErrorCode.UserPasswordRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordRequired)
                .Length(7, 21).WithState(e => ErrorCode.UserPasswordLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordLength);
            RuleFor(su => su.PasswordConfirm)
                .NotEmpty().WithState(e => ErrorCode.UserPasswordConfirmRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordConfirmRequired)
                .Equal(u => u.Password).WithState(e => ErrorCode.UserPasswordConfirmNotEqual.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordConfirmNotEqual);
            RuleFor(su => su.FirstName)
                .NotEmpty().WithState(e => ErrorCode.ProfileFirstNameRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileFirstNameRequired)
                .Length(1, 21).WithState(e => ErrorCode.ProfileFirstNameMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileFirstNameMaxLength);
            RuleFor(su => su.LastName)
                .NotEmpty().WithState(e => ErrorCode.ProfileLastNameRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileLastNameRequired)
                .Length(1, 21).WithState(e => ErrorCode.ProfileLastNameMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileLastNameMaxLength);
        }
    }
}
