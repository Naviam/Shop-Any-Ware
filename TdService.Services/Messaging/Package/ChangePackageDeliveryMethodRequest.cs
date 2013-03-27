namespace TdService.Services.Messaging.Package
{
    public class ChangePackageDeliveryMethodRequest:RequestBase
    {
        public int PackageId { get; set; }
        public int DispatchMethodId{ get; set; }
    }
}
