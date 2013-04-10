namespace TdService.Services.Messaging.Package
{
    public class ChangeTrackingNumberRequest:RequestBase
    {
        public int PackageId { get; set; }
        public string TrackingNumber { get; set; }
    }
}
