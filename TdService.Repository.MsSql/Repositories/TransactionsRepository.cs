﻿namespace TdService.Repository.MsSql.Repositories
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

        /// <summary>
        /// Confirms transaction. 
        /// </summary>
        /// <param name="token">token from PP API</param>
        /// <param name="payerId">payerId from PP API</param>
        public void ConfirmTransaction(string token, string payerId)
        {
            using (var context = new ShopAnyWareSql())
            {
                var tran = context.Transactions.SingleOrDefault(t =>t.Token.Equals(token));
                if (tran == null) throw new InvalidOperationException("Transaction Not Found");
                tran.TransactionStatus = TransactionStatus.Approved;
                tran.PayerId = payerId;
                context.Wallets.Find(tran.WalletId).Amount += tran.OperationAmount;
                context.SaveChanges();
            }
        }


        public void CancelTransaction(string token)
        {
            using (var context = new ShopAnyWareSql())
            {
                var tran = context.Transactions.SingleOrDefault(t => t.Token.Equals(token));
                if (tran == null) throw new InvalidOperationException("Transaction Not Found");
                tran.TransactionStatus = TransactionStatus.Canceled;
                context.SaveChanges();
            }
        }
    }
}
