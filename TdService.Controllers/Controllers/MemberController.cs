// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the MemberController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TdService.Infrastructure.Authentication;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Address;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.Messaging.Transactions;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Member;
    using System.Linq;
    using TdService.Infrastructure.PayPalHelpers;
    /// <summary>
    /// The controller that contains membership methods.
    /// </summary>
    public class MemberController : BaseAuthController
    {
        /// <summary>
        /// The membership service.
        /// </summary>
        private readonly IMembershipService membershipService;

        private readonly IAddressService addressService;

        private readonly ITransactionService transactionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        /// <param name="addressService">
        /// The address service.
        /// </param>
        public MemberController(IFormsAuthentication formsAuthentication, IMembershipService membershipService, IAddressService addressService, ITransactionService transactionService)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
            this.addressService = addressService;
            this.transactionService = transactionService;
        }

        /// <summary>
        /// default member action.
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult Dashboard()
        {
            var model = new ShopperDashboardViewModel();

            FillDashboardViewModelWithCommonData(model, this.FormsAuthentication.GetAuthenticationToken());
            model.UserEmail = this.FormsAuthentication.GetAuthenticationToken();

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// View shopper dashboard as admin
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        [Authorize(Roles = "Admin, Operator")]
        public ActionResult ViewShopperDashboard(string userEmail)
        {
            var model = new ShopperDashboardViewModel();
            model.AdminView = true;
            model.UserEmail = userEmail;

            FillDashboardViewModelWithCommonData(model, userEmail);

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// Testing the new interface.
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult PaymentSucceded(string token, string payerId)
        {
            var model = new ShopperDashboardViewModel();
            try
            {
                PayPalHelper.ConfirmPayPalPayment(token, payerId);

                var confirmPayPalTransactionResponse = transactionService.ConfirmPayPalTransaction(
                    new ConfirmPayPalTransactionRequest { PayerId = payerId, Token = token });
                if (confirmPayPalTransactionResponse.MessageType == Services.Messaging.MessageType.Success)
                {
                    model.PayPalTransactionResultMessage = DashboardViewResources.ResourceManager.GetString("SuccessfullPayPalPaymentConfirmationMessage");
                    model.PayPalTransactionResultMessageType = "Success";
                }
                else
                {
                    model.PayPalTransactionResultMessage = confirmPayPalTransactionResponse.Message;
                    model.PayPalTransactionResultMessageType = confirmPayPalTransactionResponse.MessageType.ToString();
                }
            }
            catch (PayPalException ex)
            {
                model.PayPalTransactionResultMessage = string.Format("{0}\n{1}",
                    DashboardViewResources.ResourceManager.GetString("FailedPayPalPaymentConfirmationMessage"),
                    ex.Message);
                model.PayPalTransactionResultMessageType = "Error";
            }

            FillDashboardViewModelWithCommonData(model, this.FormsAuthentication.GetAuthenticationToken());

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// Payment canceled
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult PaymentCanceled(string token, string payerId)
        {
            var model = new ShopperDashboardViewModel();

            var cancelPayPalTransactionResponse = transactionService.CancelPayPalTransaction(
                new CancelPayPalTransactionRequest { Token = token });

            model.PayPalTransactionResultMessage = cancelPayPalTransactionResponse.Message;
            model.PayPalTransactionResultMessageType = cancelPayPalTransactionResponse.MessageType.ToString();

            FillDashboardViewModelWithCommonData(model, this.FormsAuthentication.GetAuthenticationToken());

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// Welcome page after successful registration.
        /// </summary>
        /// <returns>
        /// View with welcome message.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult Welcome()
        {
            var model = new WelcomeViewModel();
            var response = this.membershipService.GetProfile(
                new GetProfileRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
            model.UserId = response.Id;
            model.FirstName = response.FirstName;
            model.LastName = response.LastName;

            return this.View("Welcome", model);
        }

        private void FillDashboardViewModelWithCommonData(ShopperDashboardViewModel model, string userEmail)
        {
            var response = this.membershipService.GetProfile(
               new GetProfileRequest { IdentityToken = userEmail });
            model.Email = userEmail;
            model.UserId = response.Id;
            model.FirstName = response.FirstName;
            model.LastName = response.LastName;
            model.WalletAmount = response.Balance;
            model.AmountValidationMessage = DashboardViewResources.ResourceManager.GetString("AddFundsAmountValidationMessage");
            var addressesResponse = this.addressService.GetDeliveryAddresses(new GetDeliveryAddressesRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
            model.DeliveryAddressViewModels = addressesResponse.ConvertToDeliveryAddressViewModel();
            model.AddFundsButtonText = DashboardViewResources.AddFundsButton;
            model.AddFundsLoadingText = DashboardViewResources.AddFundsButtonLoading;
            model.DeliveryMethods = new List<string> { "Standard Delivery", "Express Delivery" };
        }


    }
}