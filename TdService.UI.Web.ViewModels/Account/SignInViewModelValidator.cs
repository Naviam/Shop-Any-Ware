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

            RuleFor(si => si.Email).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.UserEmailRequired)
                .EmailAddress().WithLocalizedMessage(() => ErrorCodeResources.UserEmailInvalid)
                .Length(1, 256).WithLocalizedMessage(() => ErrorCodeResources.UserEmailMaxLength);
            RuleFor(si => si.Password).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.UserPasswordRequired)
                .Length(7, 21).WithLocalizedMessage(() => ErrorCodeResources.UserPasswordLength);
        }
    }
}