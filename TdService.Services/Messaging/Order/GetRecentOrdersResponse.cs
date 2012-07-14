namespace TdService.Services.Messaging.Order
{
    using System;

    public class GetRecentOrdersResponse : ResponseBase
    {
        public string RetailerName { get; set; }

        public string OrderNumber { get; set; }

        public string TrackingNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public string Status { get; set; }
    }
}