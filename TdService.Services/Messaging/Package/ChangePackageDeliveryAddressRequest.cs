namespace TdService.Services.Messaging.Package
{
    public class ChangePackageDeliveryAddressRequest:RequestBase
    {
        public int PackageId { get; set; }
        public int DeliverAddressId { get; set; }
    }
}
