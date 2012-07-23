// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Order view model to display order on a view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.ViewModels.Order
{
    using System;

    /// <summary>
    /// Order view model to display order on a view.
    /// </summary>
    public class OrderViewModel
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
    }
}