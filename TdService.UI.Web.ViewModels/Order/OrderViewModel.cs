// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Order view model to display order on a view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Order
{
    using System;

    using TdService.Resources;

    /// <summary>
    /// Order view model to display order on a view.
    /// </summary>
    public class OrderViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets order ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets retailer url.
        /// </summary>
        public string RetailerUrl { get; set; }

        /// <summary>
        /// Gets or sets order number.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets tracking number.
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets received date.
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// Gets or sets order status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets the status translated.
        /// </summary>
        public string StatusTranslated
        {
            get
            {
                return OrderStatusResources.ResourceManager.GetString(this.Status);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this order can be modified.
        /// </summary>
        public bool CanBeModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this order can be removed.
        /// </summary>
        public bool CanBeRemoved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this order can be removed.
        /// </summary>
        public bool CanBeReceived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this order can be requested for return.
        /// </summary>
        public bool CanBeRequestedForReturn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified { get; set; }
    }
}