using System;
using FluentValidation;
using TdService.Infrastructure.Domain;
using TdService.Resources;

namespace TdService.UI.Web.ViewModels.Account
{
    public class NewPasswordViewModelValidator : AbstractValidator<NewPasswordViewModel>
    {
        public NewPasswordViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(np => np.Password).NotEmpty().WithMessage(ErrorCodeResources.UserPasswordRequired).Length(7, 21).WithMessage(ErrorCodeResources.UserPasswordLength).Equal(
                np => np.ConfirmPassword).WithMessage(ErrorCodeResources.UserPasswordConfirmNotEqual);
        }
    }
}
