// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotPasswordViewModelValidator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The forgot password view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The forgot password view model validator.
    /// </summary>
    public class ForgotPasswordViewModelValidator : AbstractValidator<ForgotPasswordViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForgotPasswordViewModelValidator"/> class.
        /// </summary>
        public ForgotPasswordViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(fp => fp.Email).NotEmpty().WithMessage(ErrorCode.UserEmailRequired.ToString())
                .EmailAddress().WithMessage(ErrorCode.UserEmailInvalid.ToString())
                .Length(1, 256).WithMessage(ErrorCode.UserEmailMaxLength.ToString());
        }
    }
}