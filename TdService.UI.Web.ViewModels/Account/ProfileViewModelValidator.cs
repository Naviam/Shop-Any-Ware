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
    using TdService.Resources;

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

            RuleFor(p => p.FirstName)
                .NotEmpty().WithState(e => ErrorCode.ProfileFirstNameRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileFirstNameRequired)
                .Length(1, 21).WithState(e => ErrorCode.ProfileFirstNameMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileFirstNameMaxLength);
            RuleFor(p => p.LastName)
                .NotEmpty().WithState(e => ErrorCode.ProfileLastNameRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileLastNameRequired)
                .Length(1, 21).WithState(e => ErrorCode.ProfileLastNameMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.ProfileLastNameMaxLength);
        }
    }
}
