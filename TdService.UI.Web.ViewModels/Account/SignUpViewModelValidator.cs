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

            RuleFor(su => su.Email).NotEmpty().WithMessage(ErrorCode.UserEmailRequired.ToString())
                .EmailAddress().WithMessage(ErrorCode.UserEmailInvalid.ToString())
                .Length(1, 256).WithMessage(ErrorCode.UserEmailMaxLength.ToString());
            RuleFor(su => su.Password).NotEmpty().WithMessage(ErrorCode.UserPasswordRequired.ToString())
                .Length(7, 1000).WithMessage(ErrorCode.UserPasswordMinLength.ToString())
                .Length(1, 21).WithMessage(ErrorCode.UserPasswordMaxLength.ToString());
            RuleFor(su => su.PasswordConfirm).NotEmpty().WithMessage(ErrorCode.UserPasswordConfirmRequired.ToString())
                .Equal(u => u.Password).WithMessage(ErrorCode.UserPasswordConfirmNotEqual.ToString());
            RuleFor(su => su.FirstName).NotEmpty().WithMessage(ErrorCode.ProfileFirstNameRequired.ToString())
                .Length(1, 64).WithMessage(ErrorCode.ProfileFirstNameMaxLength.ToString());
            RuleFor(su => su.LastName).NotEmpty().WithMessage(ErrorCode.ProfileLastNameRequired.ToString())
                .Length(1, 64).WithMessage(ErrorCode.ProfileLastNameMaxLength.ToString());
        }
    }
}
