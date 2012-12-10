using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Model.Balance
{
    public interface ITransactionsRepository
    {
        List<Transaction> GetTransactionsForUser(string email);

        Transaction AddTransaction(Transaction transaction);

        void ConfirmTransaction(string token, string payerId);
    }
}
