namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;
    using TdService.Services.Messaging.Transactions;

    public interface ITransactionService
    {
        List<GetTransactionsResponse> GetTransactionsForUser(GetTransactionsRequest request);

        AddTransactionResponse AddTransaction(AddTransactionRequest request);

        ConfirmPayPalTransactionResponse ConfirmPayPalTransaction(ConfirmPayPalTransactionRequest request);

        CancelPayPalTransactionResponse CancelPayPalTransaction(CancelPayPalTransactionRequest confirmPayPalTransactionRequest);
    }
}
