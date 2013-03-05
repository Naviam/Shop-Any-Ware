namespace TdService.Services.Messaging.Transactions
{
    using System;

    public class GetTransactionsResponse : ResponseBase
    {
        public int WalletId { get; set; }

        /// <summary>
        /// Gets or sets Operation Amount.
        /// </summary>
        public decimal OperationAmount { get; set; }

        /// <summary>
        /// Gets or sets Operation Description.
        /// </summary>
        public string OperationDescription { get; set; }

        /// <summary>
        /// Gets or sets Commission.
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Transaction Status.
        /// </summary>
        public string TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public string Currency { get; set; }
    }
}
