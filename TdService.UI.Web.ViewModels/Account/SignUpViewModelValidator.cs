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
            RuleFor(su => su.Email).NotEmpty().WithMessage(ErrorCode.UserEmailRequired.ToString());
            RuleFor(su => su.Email).EmailAddress().WithMessage(ErrorCode.UserEmailInvalid.ToString());
            RuleFor(su => su.Email).Length(1, 256).WithMessage(ErrorCode.UserEmailMaxLength.ToString());
            RuleFor(su => su.Password).NotEmpty().WithMessage(ErrorCode.UserPasswordRequired.ToString());
            RuleFor(su => su.Password).Length(7, 1000).WithMessage(ErrorCode.UserPasswordMaxLength.ToString());
            RuleFor(su => su.Password).Length(1, 21).WithMessage(ErrorCode.UserPasswordMinLength.ToString());
            RuleFor(su => su.PasswordConfirm).NotEmpty().WithMessage(ErrorCode.UserPasswordConfirmRequired.ToString());
            RuleFor(su => su.PasswordConfirm).Equal(u => u.Password).WithMessage(
                ErrorCode.UserPasswordConfirmNotEqual.ToString());
            RuleFor(su => su.FirstName).NotEmpty().WithMessage(ErrorCode.ProfileFirstNameRequired.ToString());
            RuleFor(su => su.FirstName).Length(1, 64).WithMessage(ErrorCode.ProfileFirstNameMaxLength.ToString());
            RuleFor(su => su.LastName).NotEmpty().WithMessage(ErrorCode.ProfileLastNameRequired.ToString());
            RuleFor(su => su.LastName).Length(1, 64).WithMessage(ErrorCode.ProfileLastNameMaxLength.ToString());
        }
    }
}
