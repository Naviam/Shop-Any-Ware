namespace TdService.Services.Messaging.Item
{
    public class AddItemImageReponse:ResponseBase
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public int ItemId { get; set; }
    }
}
