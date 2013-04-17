using System;
using FluentValidation.Attributes;
namespace TdService.UI.Web.ViewModels.Account
{
    [Validator(typeof(NewPasswordViewModelValidator))]
    public class NewPasswordViewModel:ViewModelBase
    {
        public Guid PwdResetKey{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
