namespace TdService.UI.Web.ViewModels.Item
{
    public class MoveOrderItemToExistingPackageViewModel:ViewModelBase
    {
        public ItemViewModel Item { get; set; }
        public int OrderId { get; set; }
        public int PackageId { get; set; }
    }
}
