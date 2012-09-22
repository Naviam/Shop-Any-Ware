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
    using System.Threading;

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

            var culture = Thread.CurrentThread.CurrentCulture;

            RuleFor(su => su.Email).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailRequired.ToString(), culture))
                .EmailAddress().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailInvalid.ToString(), culture))
                .Length(1, 256).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailMaxLength.ToString(), culture));
            RuleFor(su => su.Password).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordRequired.ToString(), culture))
                .Length(7, 1000).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordMinLength.ToString(), culture));
                ////.Length(1, 21).WithMessage(ErrorCode.UserPasswordMaxLength.ToString());
            RuleFor(su => su.PasswordConfirm).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordConfirmRequired.ToString(), culture))
                .Equal(u => u.Password).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordConfirmNotEqual.ToString(), culture));
            RuleFor(su => su.FirstName).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.ProfileFirstNameRequired.ToString(), culture))
                .Length(1, 21).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.ProfileFirstNameMaxLength.ToString(), culture));
            RuleFor(su => su.LastName).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.ProfileLastNameRequired.ToString(), culture))
                .Length(1, 21).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.ProfileLastNameMaxLength.ToString(), culture));
        }
    }
}
