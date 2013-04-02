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
using TdService.Model.Packages;
using TdService.Resources;

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
        /// Gets or sets Wallet.
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        /// Gets or sets Transaction Status.
        /// </summary>
        public TransactionStatus? TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets PayerId
        /// </summary>
        public string PayerId{ get; set; }

        /// <summary>
        /// Gets or sets Operation Type.
        /// </summary>
        public OperationType OperationType { get; set; }

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

        public static Transaction CreatePackagePaymentTransaction(Package package)
        {
            var result = new Transaction
                {
                    Date = DateTime.UtcNow,
                    OperationAmount = 2,//HARDCODED
                    OperationDescription = string.Format("Payment for package id:{0}", package.Id),
                    OperationType = OperationType.PackagePayment,
                    TransactionStatus = null,
                    WalletId = package.User.Wallet.Id
                };
            return result;
        }
    }
}