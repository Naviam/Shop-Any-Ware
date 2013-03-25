namespace TdService.Services.Messaging.Order
{
    public class OrderReceivedRequest:RequestBase
    {
        public int OrderId { get; set; }
    }
}
