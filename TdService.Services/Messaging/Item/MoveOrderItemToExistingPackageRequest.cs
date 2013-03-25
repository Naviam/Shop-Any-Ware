namespace TdService.Services.Messaging.Item
{
    public class MoveOrderItemToExistingPackageRequest:RequestBase
    {
        public int PackageId { get; set; }
        public int ItemId { get; set; }
    }
}
