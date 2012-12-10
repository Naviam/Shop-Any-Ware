namespace TdService.Services.Messaging.Transactions
{
    using System;
    using TdService.Model.Balance;

    public class AddTransactionRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets Operation Amount.
        /// </summary>
        public decimal OperationAmount { get; set; }

        /// <summary>
        /// Gets or sets Operation Description.
        /// </summary>
        public string OperationDescription { get; set; }

       /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Transaction Status.
        /// </summary>
        public TransactionStatus TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets Token.
        /// </summary>
        public string Token{ get; set; }

        /// <summary>
        /// Gets or sets Wallet Id.
        /// </summary>
        public int WalletId { get; set; }
    }
}
