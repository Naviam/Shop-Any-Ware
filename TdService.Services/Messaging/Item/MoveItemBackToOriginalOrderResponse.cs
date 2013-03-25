using TdService.Services.Messaging.Item.Base;

namespace TdService.Services.Messaging.Item
{
    public class MoveItemBackToOriginalOrderResponse:ResponseBase
    {
        public ItemResponse Item { get; set; }

        public int OrderId { get; set; }

        public int PackageId { get; set; }
    }
}
