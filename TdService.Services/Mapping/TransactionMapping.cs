namespace TdService.Services.Mapping
{
    using System.Collections.Generic;
    using AutoMapper;
    using TdService.Model.Balance;
    using TdService.Services.Messaging.Transactions;

    public static class TransactionMapping
    {
        /// <summary>
        /// Convert transactions to get transactions response.
        /// </summary>
        /// <param name="transactions">
        /// Transactions.
        /// </param>
        /// <returns>
        /// Collection of get transactions responses.
        /// </returns>
        public static List<GetTransactionsResponse> ConvertToGetTransactionsResponseCollection(this List<Transaction> transactions)
        {
            return Mapper.Map<List<Transaction>, List<GetTransactionsResponse>>(transactions);
        }

        /// <summary>
        /// Convert transaction to add transaction response message.
        /// </summary>
        /// <param name="transaction">
        /// The transaction.
        /// </param>
        /// <returns></returns>
        public static AddTransactionResponse ConvertToAddTransactionResponse(this Transaction transaction)
        {
            return Mapper.Map<Transaction, AddTransactionResponse>(transaction);
        }

        /// <summary>
        /// Convert add transaction request to transaction.
        /// </summary>
        /// <param name="request">
        /// The add transaction request.
        /// </param>
        /// <returns></returns>
        public static Transaction ConvertToTransaction(this AddTransactionRequest request)
        {
            return Mapper.Map<AddTransactionRequest, Transaction>(request);
        }
    }
}
