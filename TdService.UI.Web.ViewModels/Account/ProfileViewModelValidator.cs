// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProfileViewModelValidator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The profile view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The profile view model validator.
    /// </summary>
    public class ProfileViewModelValidator : AbstractValidator<ProfileViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileViewModelValidator"/> class.
        /// </summary>
        public ProfileViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.FirstName).NotEmpty().WithMessage(ErrorCode.ProfileFirstNameRequired.ToString())
                .Length(1, 21).WithMessage(ErrorCode.ProfileFirstNameMaxLength.ToString());
            RuleFor(p => p.LastName).NotEmpty().WithMessage(ErrorCode.ProfileLastNameRequired.ToString())
                .Length(1, 21).WithMessage(ErrorCode.ProfileLastNameMaxLength.ToString());
        }
    }
}
