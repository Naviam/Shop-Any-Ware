namespace TdService.UI.Web.ViewModels.Ballance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TdService.Resources;

    /// <summary>
    /// Transactions ViewM odel
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
    }
}
