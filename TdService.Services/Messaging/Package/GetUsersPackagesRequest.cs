namespace TdService.Services.Messaging.Package
{
    public class GetUsersPackagesRequest:RequestBase
    {
        public bool IncludeAssembling { get; set; }
        public bool IncludePaid { get; set; }
        public bool IncludeSent { get; set; }
    }
}
