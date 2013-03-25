using System.Collections.Generic;
using TdService.Services.Messaging.Item.Base;
namespace TdService.Services.Messaging.Item
{
    public class MoveOrderItemsToNewPackageResponse : ResponseBase
    {
        public List<ItemResponse> Items { get; set; }

        public int PackageId { get; set; }
    }
}
