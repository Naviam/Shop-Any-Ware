// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionsViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The transactions view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Ballance
{
    using System;
    using TdService.Resources;

    /// <summary>
    /// The transactions view model.
    /// </summary>
    public class TransactionsViewModel : ViewModelBase
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
        /// Gets  Date string.
        /// </summary>
        public string DateString
        {
            get
            {
                return this.Date.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets or sets Transaction Status.
        /// </summary>
        public string TransactionStatus { get; set; }

        /// <summary>
        /// Gets the status translated.
        /// </summary>
        public string StatusTranslated
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.TransactionStatus))
                {
                    return TransactionStatusesResources.ResourceManager.GetString(this.TransactionStatus);
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the wallet id.
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Gets the operation type translated.
        /// </summary>
        public string OperationTypeTranslated
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.OperationType) ? TransactionStatusesResources.ResourceManager.GetString(this.OperationType) : string.Empty;
            }
        }
    }
}
