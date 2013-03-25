using System.Collections.Generic;
using TdService.Services.Messaging.Item.Base;
namespace TdService.Services.Messaging.Item
{
    public class MoveOrderItemsToOriginalOrderResponse : ResponseBase
    {
        public List<ItemResponse> Items { get; set; }

        public int PackageId { get; set; }
    }
}
