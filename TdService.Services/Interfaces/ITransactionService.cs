// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITransactionService.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The TransactionService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;
    using TdService.Services.Messaging.Package;
    using TdService.Services.Messaging.Transactions;

    /// <summary>
    /// The TransactionService interface.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// The get transactions for user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of get transactions responses.
        /// </returns>
        List<GetTransactionsResponse> GetTransactionsForUser(GetTransactionsRequest request);

        /// <summary>
        /// The add transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="AddTransactionResponse"/>.
        /// </returns>
        AddTransactionResponse AddTransaction(AddTransactionRequest request);

        /// <summary>
        /// The confirm pay pal transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ConfirmPayPalTransactionResponse"/>.
        /// </returns>
        ConfirmPayPalTransactionResponse ConfirmPayPalTransaction(ConfirmPayPalTransactionRequest request);

        /// <summary>
        /// The cancel pay pal transaction.
        /// </summary>
        /// <param name="confirmPayPalTransactionRequest">
        /// The confirm pay pal transaction request.
        /// </param>
        /// <returns>
        /// The <see cref="CancelPayPalTransactionResponse"/>.
        /// </returns>
        CancelPayPalTransactionResponse CancelPayPalTransaction(CancelPayPalTransactionRequest confirmPayPalTransactionRequest);

        /// <summary>
        /// The add package payment transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="PayForPackageResponse"/>.
        /// </returns>
        PayForPackageResponse AddPackagePaymentTransaction(PayForPackageRequest request);
    }
}
