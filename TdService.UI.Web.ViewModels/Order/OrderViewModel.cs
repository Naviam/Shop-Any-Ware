﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// Gets or sets the returned date.
        /// </summary>
        public DateTime? ReturnedDate { get; set; }

        /// <summary>
        /// Gets created date.
        /// </summary>
        public string CreatedDateString
        {
            get
            {
                return this.CreatedDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets received date.
        /// </summary>
        public string ReceivedDateString
        {
            get
            {
                return this.ReceivedDate.HasValue ? this.ReceivedDate.Value.ToShortDateString() : string.Empty;
            }
        }

        /// <summary>
        /// Gets the returned date.
        /// </summary>
        public string ReturnedDateString
        {
            get
            {
                return this.ReturnedDate.HasValue ? this.ReturnedDate.Value.ToShortDateString() : string.Empty;
            }
        }

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
                if (!string.IsNullOrWhiteSpace(this.Status))
                {
                    return OrderStatusResources.ResourceManager.GetString(this.Status);
                }

                return string.Empty;
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

        /// <summary>
        /// Gets or sets a value indicating whether can items be added.
        /// </summary>
        public bool CanItemsBeAdded { get; set; }
    }
}