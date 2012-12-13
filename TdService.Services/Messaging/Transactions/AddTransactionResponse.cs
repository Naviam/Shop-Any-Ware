﻿namespace TdService.Services.Messaging.Transactions
{
    public class AddTransactionResponse : ResponseBase
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
        public decimal Commission { get; set; }//TODO: count comission

        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets Transaction Amount.
        /// </summary>
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets Transaction Status.
        /// </summary>
        public string TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// PayPal Redirect Url
        /// </summary>
        public string PayPalRedirectUrl { get; set; }
    }
}