namespace TdService.Services.Messaging.Item
{
    public class EditOrderItemRequest : AddItemToOrderRequest
    {
        /// <summary>
        /// Existing order item Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Specifies whether update is perfomed by operator
        /// </summary>
        public bool OperatorMode { get; set; }
    }
}
