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
    using System.Web.Mvc;
    using System.Xml;
    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Transactions;
    using TdService.UI.Web.Mapping;

    /// <summary>
    /// This controller contains methods to work with balance.
    /// </summary>
    public class BallanceController : BaseAuthController
    {
        /// <summary>
        /// Order service.
        /// </summary>
        private readonly ITransactionService transactionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BallanceController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public BallanceController(ITransactionService transactionService, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
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

    }
}
