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
    using TdService.Resources.Views;
    using TdService.UI.Web.ViewModels.Account;
    using TdService.UI.Web.ViewModels.Package;

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
        public List<DispatchMethodViewModel> DeliveryMethods { get; set; }

        /// <summary>
        /// Gets or sets the amount validation message.
        /// </summary>
        public string AmountValidationMessage { get; set; }

        /// <summary>
        /// Gets or sets the pay pal transaction result message.
        /// </summary>
        public string PayPalTransactionResultMessage { get; set; }

        /// <summary>
        /// Gets or sets the pay pal transaction result message type.
        /// </summary>
        public string PayPalTransactionResultMessageType { get; set; }

        /// <summary>
        /// Gets or sets the add funds loading text.
        /// </summary>
        public string AddFundsLoadingText { get; set; }

        /// <summary>
        /// Gets or sets the add funds button text.
        /// </summary>
        public string AddFundsButtonText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether admin view.
        /// </summary>
        public bool AdminView { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets the admin view notice message.
        /// </summary>
        public string AdminViewNoticeMessage
        {
            get
            {
                var message = DashboardViewResources.ResourceManager.GetString("AdminViewNoticeMessage");
                return (message != null) ? string.Format(message, this.UserId, this.UserEmail) : null;
            }
        }

        /// <summary>
        /// Gets the name is required.
        /// </summary>
        public string NameIsRequired
        {
            get
            {
                return DashboardViewResources.NameIsRequired;
            }
        }

        /// <summary>
        /// Gets the quantity is required.
        /// </summary>
        public string QuantityIsRequired
        {
            get
            {
                return DashboardViewResources.QuantityIsRequired;
            }
        }

        /// <summary>
        /// Gets the price is required.
        /// </summary>
        public string PriceIsRequired
        {
            get
            {
                return DashboardViewResources.PriceIsRequired;
            }
        }

        /// <summary>
        /// Gets the invalid price.
        /// </summary>
        public string InvalidPrice
        {
            get
            {
                return DashboardViewResources.InvalidPrice;
            }
        }

        /// <summary>
        /// Gets the invalid weight.
        /// </summary>
        public string InvalidWeight
        {
            get
            {
                return DashboardViewResources.InvalidWeight;
            }
        }

        /// <summary>
        /// Gets the invalid height.
        /// </summary>
        public string InvalidHeight
        {
            get
            {
                return DashboardViewResources.InvalidHeight;
            }
        }

        /// <summary>
        /// Gets the invalid length.
        /// </summary>
        public string InvalidLength
        {
            get
            {
                return DashboardViewResources.InvalidLength;
            }
        }

        /// <summary>
        /// Gets the invalid width.
        /// </summary>
        public string InvalidWidth
        {
            get
            {
                return DashboardViewResources.InvalidWidth;
            }
        }

        /// <summary>
        /// Gets the invalid girth.
        /// </summary>
        public string InvalidGirth
        {
            get
            {
                return DashboardViewResources.InvalidGirth;
            }
        }

        /// <summary>
        /// Gets the invalid quantity.
        /// </summary>
        public string InvalidQuantity
        {
            get
            {
                return DashboardViewResources.InvalidQuantity;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether operator mode.
        /// </summary>
        public bool OperatorMode { get; set; }

        /// <summary>
        /// Gets or sets the USPS tracking url.
        /// </summary>
        public string UspsTrackingUrl { get; set; }
    }
}