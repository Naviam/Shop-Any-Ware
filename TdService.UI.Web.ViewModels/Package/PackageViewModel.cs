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
        /// Gets or sets the dispatch method.
        /// </summary>
        public int? DispatchMethod { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets the status translated.
        /// </summary>
        public string StatusTranslated
        {
            get
            {
                if (string.IsNullOrEmpty(this.Status)) return null;
                return PackageStatusResources.ResourceManager.GetString(this.Status);
            }
        }

        /// <summary>
        /// Gets or sets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets Dispatched Date.
        /// </summary>
        public DateTime? DispatchedDate { get; set; }

        /// <summary>
        /// Gets or sets Delivered Date.
        /// </summary>
        public DateTime? DeliveredDate { get; set; }

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
        ///  Gets a value indicating whether package can be paid.
        /// </summary>
        public bool CanBePaidFor { get; set; }
    }
}