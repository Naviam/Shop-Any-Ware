// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionMapping.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The transaction mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using System.Collections.Generic;
    using AutoMapper;
    using TdService.Model.Balance;
    using TdService.Services.Messaging.Transactions;

    /// <summary>
    /// The transaction mapping.
    /// </summary>
    public static class TransactionMapping
    {
        /// <summary>
        /// The convert to get transactions response collection.
        /// </summary>
        /// <param name="transactions">
        /// The transactions.
        /// </param>
        /// <returns>
        /// The collection of get transactions responses.
        /// </returns>
        public static List<GetTransactionsResponse> ConvertToGetTransactionsResponseCollection(this List<Transaction> transactions)
        {
            return Mapper.Map<List<Transaction>, List<GetTransactionsResponse>>(transactions);
        }

        /// <summary>
        /// The convert to add transaction response.
        /// </summary>
        /// <param name="transaction">
        /// The transaction.
        /// </param>
        /// <returns>
        /// The <see cref="AddTransactionResponse"/>.
        /// </returns>
        public static AddTransactionResponse ConvertToAddTransactionResponse(this Transaction transaction)
        {
            return Mapper.Map<Transaction, AddTransactionResponse>(transaction);
        }

        /// <summary>
        /// The convert to transaction.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Transaction"/>.
        /// </returns>
        public static Transaction ConvertToTransaction(this AddTransactionRequest request)
        {
            return Mapper.Map<AddTransactionRequest, Transaction>(request);
        }
    }
}
