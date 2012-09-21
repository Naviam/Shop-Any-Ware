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
    using TdService.Resources;

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

            RuleFor(si => si.Email).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailRequired.ToString()))
                .EmailAddress().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailInvalid.ToString()))
                .Length(1, 256).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailMaxLength.ToString()));
            RuleFor(si => si.Password).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordRequired.ToString()))
                .Length(7, 1000).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordMinLength.ToString()));
                ////.Length(1, 21).WithMessage(ErrorCode.UserPasswordMaxLength.ToString());
        }
    }
}