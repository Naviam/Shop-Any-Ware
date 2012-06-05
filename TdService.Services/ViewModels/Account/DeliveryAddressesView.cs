// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressesView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.ViewModels.Account
{
    using System.Collections.Generic;

    using TdService.Model.Addresses;

    /// <summary>
    /// The class describes the delivery addresses view model.
    /// </summary>
    public class DeliveryAddressesView : BaseView
    {
        /// <summary>
        /// Gets or sets Delivery Address Book.
        /// </summary>
        public List<DeliveryAddress> DeliveryAddressBook { get; set; }

        /// <summary>
        /// Gets or sets DeliveryAddressView.
        /// </summary>
        public DeliveryAddressDetails DeliveryAddressView { get; set; }
    }
}