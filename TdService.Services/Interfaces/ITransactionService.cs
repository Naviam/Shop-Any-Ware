namespace TdService.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TdService.Services.Messaging.Transactions;

    public interface ITransactionService
    {
        List<GetTransactionsResponse> GetTransactionsForUser(GetTransactionsRequest request);
    }
}
