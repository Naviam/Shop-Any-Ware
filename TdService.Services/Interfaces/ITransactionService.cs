namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;
using TdService.Services.Messaging.Package;
using TdService.Services.Messaging.Transactions;

    public interface ITransactionService
    {
        List<GetTransactionsResponse> GetTransactionsForUser(GetTransactionsRequest request);

        /// <summary>
        /// Add PP transaction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddTransactionResponse AddTransaction(AddTransactionRequest request);

        ConfirmPayPalTransactionResponse ConfirmPayPalTransaction(ConfirmPayPalTransactionRequest request);

        CancelPayPalTransactionResponse CancelPayPalTransaction(CancelPayPalTransactionRequest confirmPayPalTransactionRequest);

        /// <summary>
        /// Add package payment transaction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PayForPackageResponse AddPackagePaymentTransaction(PayForPackageRequest request);
    }
}
