// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopperDashboardViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The shopper dashboard view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Member
{
    using System.Collections.Generic;

    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The shopper dashboard view model.
    /// </summary>
    public class ShopperDashboardViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the wallet amount.
        /// </summary>
        public decimal WalletAmount { get; set; }

        /// <summary>
        /// Gets or sets the delivery address view models.
        /// </summary>
        public List<DeliveryAddressViewModel> DeliveryAddressViewModels { get; set; }

        /// <summary>
        /// Gets or sets the delivery methods.
        /// </summary>
        public List<string> DeliveryMethods { get; set; }
    }
}