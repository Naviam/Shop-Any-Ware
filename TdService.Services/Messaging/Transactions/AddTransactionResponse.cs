// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTransactionResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The add transaction response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Transactions
{
    /// <summary>
    /// The add transaction response.
    /// </summary>
    public class AddTransactionResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the wallet id.
        /// </summary>
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
        public decimal Commission { get; set; } // TODO: count comission

        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets Transaction Status.
        /// </summary>
        public string TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the pay pal redirect url.
        /// </summary>
        public string PayPalRedirectUrl { get; set; }
    }
}