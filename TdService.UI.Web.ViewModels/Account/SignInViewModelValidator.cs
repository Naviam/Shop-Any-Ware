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
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(si => si.Email)
                .NotEmpty().WithState(e => ErrorCode.UserEmailRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserEmailRequired)
                .EmailAddress().WithState(e => ErrorCode.UserEmailInvalid.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserEmailInvalid)
                .Length(1, 256).WithState(e => ErrorCode.UserEmailMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserEmailMaxLength);
            RuleFor(si => si.Password)
                .NotEmpty().WithState(e => ErrorCode.UserPasswordRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordRequired);
        }
    }
}