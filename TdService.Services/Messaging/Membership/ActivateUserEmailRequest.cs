using System;

namespace TdService.Services.Messaging.Membership
{
    public class ActivateUserEmailRequest
    {
        public int UserId { get; set; }
        public Guid ActivationCode { get; set; }
    }
}
