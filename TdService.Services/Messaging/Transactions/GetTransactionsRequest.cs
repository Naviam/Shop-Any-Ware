namespace TdService.Services.Messaging.Transactions
{
    public class GetTransactionsRequest:RequestBase
    {
        /// <summary>
        /// Gets or sets the take.
        /// </summary>
        public int Take { get; set; }
    }
}
