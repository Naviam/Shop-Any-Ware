namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TdService.Model.Balance;

    public class TransactionsRepository : ITransactionsRepository
    {

        public List<Transaction> GetTransactionsForUser(string email)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("Wallet.Transactions").Single(u => u.Email.Equals(email));

                return user.Wallet.Transactions;
            }
        }

        public Transaction AddTransaction(Transaction transaction)
        {
            using (var context = new ShopAnyWareSql())
            {
                var result = context.Transactions.Add(transaction);
                context.SaveChanges();
                return result;
            }
        }
    }
}
