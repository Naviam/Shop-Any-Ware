// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Package
{
    using System;

    using TdService.Resources;

    /// <summary>
    /// The package view model.
    /// </summary>
    public class PackageViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets package ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the delivery address id.
        /// </summary>
        public int? DeliveryAddressId { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the dispatch method.
        /// </summary>
        public int? DispatchMethod { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the total weight.
        /// </summary>
        public decimal TotalWeight { get; set; }

        /// <summary>
        /// Gets or sets the dimensions length.
        /// </summary>
        public decimal DimensionsLength { get; set; }

        /// <summary>
        /// Gets or sets the dimensions height.
        /// </summary>
        public decimal DimensionsHeight { get; set; }

        /// <summary>
        /// Gets or sets the dimensions width.
        /// </summary>
        public decimal DimensionsWidth { get; set; }

        /// <summary>
        /// Gets or sets the dimensions girth.
        /// </summary>
        public decimal DimensionsGirth { get; set; }

        /// <summary>
        /// Gets the status translated.
        /// </summary>
        public string StatusTranslated
        {
            get
            {
                return string.IsNullOrEmpty(this.Status) ? null : PackageStatusResources.ResourceManager.GetString(this.Status);
            }
        }

        /// <summary>
        /// Gets or sets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets created date string
        /// </summary>
        public string CreatedDateString
        {
            get
            {
                return this.CreatedDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets or sets Dispatched Date.
        /// </summary>
        public DateTime? DispatchedDate { get; set; }

        /// <summary>
        /// Gets Dispatched Date string.
        /// </summary>
        public string DispatchedDateString
        {
            get
            {
                return this.DispatchedDate.HasValue ? this.DispatchedDate.Value.ToShortDateString() : string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets Delivered Date.
        /// </summary>
        public DateTime? DeliveredDate { get; set; }

        /// <summary>
        /// Gets Delivered Date.
        /// </summary>
        public string DeliveredDateString
        {
            get
            {
                return this.DeliveredDate.HasValue ? this.DeliveredDate.Value.ToShortDateString() : string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether can be modified.
        /// </summary>
        public bool CanBeModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be sent.
        /// </summary>
        public bool CanBeSent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be removed.
        /// </summary>
        public bool CanBeRemoved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be disposed.
        /// </summary>
        public bool CanBeDisposed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be assembled.
        /// </summary>
        public bool CanBeAssembled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can be paid for.
        /// </summary>
        public bool CanBePaidFor { get; set; }

        /// <summary>
        /// Gets the loading text.
        /// </summary>
        public string LoadingText
        {
            get
            {
                return CommonResources.LoadingText;
            }
        }

        /// <summary>
        /// Gets or sets Tracking Number
        /// </summary>
        public string TrackingNumber { get; set; }
    }
}