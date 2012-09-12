// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInViewModelValidator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The sign in view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The sign in view model validator.
    /// </summary>
    public class SignInViewModelValidator : AbstractValidator<SignInViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignInViewModelValidator"/> class.
        /// </summary>
        public SignInViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(si => si.Email).NotEmpty().WithMessage(ErrorCode.UserEmailRequired.ToString())
                .EmailAddress().WithMessage(ErrorCode.UserEmailInvalid.ToString())
                .Length(1, 256).WithMessage(ErrorCode.UserEmailMaxLength.ToString());
            RuleFor(si => si.Password).NotEmpty().WithMessage(ErrorCode.UserPasswordRequired.ToString())
                .Length(7, 1000).WithMessage(ErrorCode.UserPasswordMinLength.ToString())
                .Length(1, 21).WithMessage(ErrorCode.UserPasswordMaxLength.ToString());
        }
    }
}