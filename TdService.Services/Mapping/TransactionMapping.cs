namespace TdService.Services.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
    }
}
