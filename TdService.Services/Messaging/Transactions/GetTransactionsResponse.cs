// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetTransactionsResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get transactions response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Transactions
{
    using System;

    /// <summary>
    /// The get transactions response.
    /// </summary>
    public class GetTransactionsResponse : ResponseBase
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

        /// <summary>
        /// Gets or sets Operation Type.
        /// </summary>
        public string OperationType { get; set; }
    }
}
