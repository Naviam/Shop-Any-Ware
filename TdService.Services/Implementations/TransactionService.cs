namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
       
    }
}
