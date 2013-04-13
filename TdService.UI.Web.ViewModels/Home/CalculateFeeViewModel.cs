namespace TdService.UI.Web.ViewModels.Home
{
    public class CalculateFeeViewModel
    {
        public int Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Girth { get; set; }
        public decimal Amount{ get; set; }
        public string CountryName { get; set; }
        public int DeliveryMethodId { get; set; }
    }
}
