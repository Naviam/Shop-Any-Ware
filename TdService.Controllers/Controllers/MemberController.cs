﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the MemberController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.PayPalHelpers;
    using TdService.Model.Shipping;
    using TdService.Resources;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Address;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.Messaging.Transactions;
    using TdService.UI.Web.Controllers.Base;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Member;
    using TdService.UI.Web.ViewModels.Package;

    /// <summary>
    /// The controller that contains membership methods.
    /// </summary>
    public class MemberController : BaseAuthController
    {
        /// <summary>
        /// The membership service.
        /// </summary>
        private readonly IMembershipService membershipService;

        /// <summary>
        /// The address service.
        /// </summary>
        private readonly IAddressService addressService;

        /// <summary>
        /// The transaction service.
        /// </summary>
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
        /// <param name="transactionService">
        /// The transaction Service.
        /// </param>
        public MemberController(
            IFormsAuthentication formsAuthentication,
            IMembershipService membershipService,
            IAddressService addressService,
            ITransactionService transactionService)
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

            this.FillDashboardViewModelWithCommonData(model, this.FormsAuthentication.GetAuthenticationToken());
            model.UserEmail = this.FormsAuthentication.GetAuthenticationToken();

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// View shopper dashboard as admin
        /// </summary>
        /// <param name="userEmail">
        /// The user Email.
        /// </param>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        [Authorize(Roles = "Admin, Operator, Admin")]
        public ActionResult ViewShopperDashboard(string userEmail)
        {
            var model = new ShopperDashboardViewModel { UserEmail = userEmail, OperatorMode = true };

            this.FillDashboardViewModelWithCommonData(model, userEmail);

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// Testing the new interface.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="payerId">
        /// The payer Id.
        /// </param>
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

                var confirmPayPalTransactionResponse = this.transactionService.ConfirmPayPalTransaction(
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
                model.PayPalTransactionResultMessage = string.Format(
                    "{0}\n{1}",
                    DashboardViewResources.ResourceManager.GetString("FailedPayPalPaymentConfirmationMessage"),
                    ex.Message);
                model.PayPalTransactionResultMessageType = "Error";
            }

            this.FillDashboardViewModelWithCommonData(model, this.FormsAuthentication.GetAuthenticationToken());

            return this.View("Dashboard", model);
        }

        /// <summary>
        /// The payment canceled.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="payerId">
        /// The payer id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        public ActionResult PaymentCanceled(string token, string payerId)
        {
            var model = new ShopperDashboardViewModel();

            var cancelPayPalTransactionResponse = this.transactionService.CancelPayPalTransaction(
                new CancelPayPalTransactionRequest { Token = token });

            model.PayPalTransactionResultMessage = cancelPayPalTransactionResponse.Message;
            model.PayPalTransactionResultMessageType = cancelPayPalTransactionResponse.MessageType.ToString();

            this.FillDashboardViewModelWithCommonData(model, this.FormsAuthentication.GetAuthenticationToken());

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

        /// <summary>
        /// The fill dashboard view model with common data.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="userEmail">
        /// The user email.
        /// </param>
        private void FillDashboardViewModelWithCommonData(ShopperDashboardViewModel model, string userEmail)
        {
            var response = this.membershipService.GetProfile(
               new GetProfileRequest { IdentityToken = userEmail });
            model.UserEmail = userEmail;
            model.UspsTrackingUrl = ConfigurationManager.AppSettings["UspsTrackingUrl"];
            model.UserId = response.Id;
            model.FirstName = response.FirstName;
            model.LastName = response.LastName;
            model.WalletAmount = response.Balance;
            model.AmountValidationMessage = DashboardViewResources.ResourceManager.GetString("AddFundsAmountValidationMessage");
            var addressesResponse = this.addressService.GetDeliveryAddresses(new GetDeliveryAddressesRequest { IdentityToken = userEmail });
            model.DeliveryAddressViewModels = addressesResponse.ConvertToDeliveryAddressViewModel();
            model.AddFundsButtonText = DashboardViewResources.AddFundsButton;
            model.AddFundsLoadingText = DashboardViewResources.AddFundsButtonLoading;
            model.DeliveryMethods = Enum.GetValues(typeof(DispatchMethod))
                                    .Cast<DispatchMethod>()
                                    .Select(enumElement => new DispatchMethodViewModel { Id = (int)enumElement, Name = DispatchMethods.ResourceManager.GetString(enumElement.ToString()) }).ToList();
        }
    }
}