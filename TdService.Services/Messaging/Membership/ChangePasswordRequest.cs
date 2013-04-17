using System;
namespace TdService.Services.Messaging.Membership
{
    public class ChangePasswordRequest:RequestBase
    {
        public string Password { get; set; }
        public Guid PasswordResetKey { get; set; }
    }
}
