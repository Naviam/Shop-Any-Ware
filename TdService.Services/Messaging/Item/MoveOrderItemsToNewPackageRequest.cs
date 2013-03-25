namespace TdService.Services.Messaging.Item
{
    public class MoveOrderItemsToNewPackageRequest:RequestBase
    {
        public int OrderId { get; set; }
        public string PackageName { get; set; }
    }
}
