using System.Collections.Generic;
using TdService.Services.Messaging.Item.Base;
namespace TdService.Services.Messaging.Item
{
    public class MoveOrderItemsToExistingPackageResponse : ResponseBase
    {
        public List<ItemResponse> Items { get; set; }
        public int PackageId { get; set; }
    }
}
