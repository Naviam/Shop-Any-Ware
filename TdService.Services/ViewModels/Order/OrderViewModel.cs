namespace TdService.Services.ViewModels.Order
{
    using System;

    public class OrderViewModel
    {
        public int Id { get; set; }

        public string RetailerName { get; set; }

        public string OrderNumber { get; set; }

        public string TrackingNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ReceivedDate { get; set; }
    }
}