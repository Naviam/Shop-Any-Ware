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
    using System.Threading;

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

            var culture = Thread.CurrentThread.CurrentCulture;

            RuleFor(si => si.Email).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailRequired.ToString(), culture))
                .EmailAddress().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailInvalid.ToString(), culture))
                .Length(1, 256).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailMaxLength.ToString(), culture));
            RuleFor(si => si.Password).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordRequired.ToString(), culture))
                .Length(7, 1000).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordMinLength.ToString(), culture));
                ////.Length(1, 21).WithMessage(ErrorCode.UserPasswordMaxLength.ToString());
        }
    }
}