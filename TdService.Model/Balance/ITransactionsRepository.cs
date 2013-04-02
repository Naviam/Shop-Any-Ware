using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdService.Model.Packages;

namespace TdService.Model.Balance
{
    public interface ITransactionsRepository
    {
        List<Transaction> GetTransactionsForUser(string email);

        Transaction AddTransaction(Transaction transaction);

        void ConfirmTransaction(string token, string payerId);

        void CancelTransaction(string token);

        /// <summary>
        /// Adds package transaction
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns>Tuple of package  and actual wallet amount</returns>
        Tuple<Package, decimal> AddPackagePaymentTransaction(int packageId);
    }
}
