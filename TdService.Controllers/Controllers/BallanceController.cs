﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BalanceController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the BalanceController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;
    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.PayPalHelpers;
    using TdService.Model.Balance;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Transactions;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Ballance;

    /// <summary>
    /// This controller contains methods to work with balance.
    /// </summary>
    public class BallanceController : BaseAuthController
    {
        private readonly IMembershipService membershipService;

        /// <summary>
        /// Order service.
        /// </summary>
        private readonly ITransactionService transactionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BallanceController"/> class.
        /// </summary>
        /// <param name="transactionService"></param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public BallanceController(IMembershipService membershipService, ITransactionService transactionService, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
            this.transactionService = transactionService;
        }

        /// <summary>
        /// Get transaction history.
        /// </summary>
        /// <returns>
        /// Get transaction history in JSON formatted result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult TransactionHistory()
        {
            var request = new GetTransactionsRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.transactionService.GetTransactionsForUser(request);
            var result = response.ConvertToTransactionsViewModelCollection();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult AddTransaction(decimal amount)
        {
            try
            {
                //get token from paypal
                var token = PayPalHelper.GetTokenFromPayPalApi(amount,
                    ResolveServerUrl(VirtualPathUtility.ToAbsolute(Url.Action("PaymentSucceded", "Member")), false),
                    ResolveServerUrl(VirtualPathUtility.ToAbsolute(Url.Action("DepositCanceled", "Member")), false),
                    "SAW sandbox test deposit",
                    "SAW");

                var profile =
                membershipService.GetProfile(
                    new Services.Messaging.Membership.GetProfileRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
                var request = new AddTransactionRequest
                {
                    Date = DateTime.Now,
                    IdentityToken = this.FormsAuthentication.GetAuthenticationToken(),
                    OperationAmount = amount,
                    OperationDescription = "PayPal transaction",
                    TransactionStatus = TransactionStatus.InProgress,
                    Token = token,
                    WalletId = profile.WalletId

                };
                var response = this.transactionService.AddTransaction(request);
                var jsonNetResult = new JsonNetResult
                {
                    Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                    Data = new { Message = response.Message, MessageType = response.MessageType.ToString(), RedirectUrl = PayPalHelper.GetRedirectUrl(token) }
                };
                return jsonNetResult;
            }
            catch (PayPalException ex)
            {
                var jsonNetResult = new JsonNetResult
                {
                    Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                    Data = new { Message = ex.Message, MessageType="Error" }
                };
                return jsonNetResult;
            }
        }

        private static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;

            string newUrl = serverUrl;
            Uri originalUri = System.Web.HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        }
    }
}
