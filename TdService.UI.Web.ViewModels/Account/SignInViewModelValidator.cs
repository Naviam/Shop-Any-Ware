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
    using System.Globalization;
    using System.Web;

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

            var culture = new CultureInfo("en-US");
            if (HttpContext.Current.Request.Cookies["culture"] != null)
            {
                var cultureText = HttpContext.Current.Request.Cookies["culture"].Value;
                culture = new CultureInfo(cultureText);
            }

            RuleFor(si => si.Email).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailRequired.ToString(), culture))
                .EmailAddress().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailInvalid.ToString(), culture))
                .Length(1, 256).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserEmailMaxLength.ToString(), culture));
            RuleFor(si => si.Password).NotEmpty().WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordRequired.ToString(), culture))
                .Length(7, 1000).WithMessage(ErrorCodeResources.ResourceManager.GetString(ErrorCode.UserPasswordMinLength.ToString(), culture));
                ////.Length(1, 21).WithMessage(ErrorCode.UserPasswordMaxLength.ToString());
        }
    }
}