namespace TdService.Services.Messaging.Item
{
    public class MoveOrderItemsToExistingPackageRequest:RequestBase
    {
        public int OrderId { get; set; }
        public int PackageId { get; set; }
    }
}
