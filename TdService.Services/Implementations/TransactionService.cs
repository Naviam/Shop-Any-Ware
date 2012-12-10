namespace TdService.Services.Implementations
{
    using System.Collections.Generic;
    using TdService.Model.Balance;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Transactions;
    using TdService.Services.Mapping;

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionsRepository transactionsRepository;

        public TransactionService(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public List<GetTransactionsResponse> GetTransactionsForUser(GetTransactionsRequest request)
        {
            var result = this.transactionsRepository.GetTransactionsForUser(request.IdentityToken);
            return result.ConvertToGetTransactionsResponseCollection();
        }

        public AddTransactionResponse AddTransaction(AddTransactionRequest request)
        {
            var transaction = request.ConvertToTransaction();
            transaction.Wallet = new Wallet { Id = request.WalletId };
            var result = this.transactionsRepository.AddTransaction(transaction);
            return result.ConvertToAddTransactionResponse();
        }
    }
}
