namespace TdService.Infrastructure.Usps
{
    public class ShippingRatesResponse
    {
        public string Error { get; set; }
        public decimal? ExpressMailPostagePrice { get; set; }
        public decimal? PriorityMailPostagePrice { get; set; }
    }
}
