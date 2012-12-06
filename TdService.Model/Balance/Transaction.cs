// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Transaction.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Wire transaction details
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Balance
{
    using System;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Balance.BusinessRules;

    /// <summary>
    /// Wire transaction details
    /// </summary>
    public class Transaction : EntityBase<int>
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
        /// Gets or sets Commission.
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets Transaction Amount.
        /// </summary>
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// Gets or sets Wallet.
        /// </summary>
        public Wallet Wallet { get; set; }

        /// <summary>
        /// Gets or sets Transaction Status.
        /// </summary>
        public TransactionStatus TransactionStatus { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        protected override void Validate()
        {
            if (this.OperationAmount==0)
                this.AddBrokenRule(TransactionBusinessRules.TransactionOperationAmountRequired);
        }
    }
}