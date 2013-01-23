namespace TdService.Services.Messaging.Membership
{
    public class SignUpAdminRequest : RequestBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool AdminRole { get; set; }
        public bool OperatorRole { get; set; }
    }
}
