namespace TdService.Services.Messaging.Item
{
    public class MoveOrderItemsToOriginalOrderRequest:RequestBase
    {
        public int PackageId { get; set; }
    }
}
