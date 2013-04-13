// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITransactionsRepository.cs" company="Naviam">
//   Vadim Shaporov. 2013.
// </copyright>
// <summary>
//   The TransactionsRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Balance
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Packages;

    /// <summary>
    /// The TransactionsRepository interface.
    /// </summary>
    public interface ITransactionsRepository
    {
        /// <summary>
        /// The get transactions for user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// Collection of transactions.
        /// </returns>
        List<Transaction> GetTransactionsForUser(string email);

        /// <summary>
        /// The add transaction.
        /// </summary>
        /// <param name="transaction">
        /// The transaction.
        /// </param>
        /// <returns>
        /// The <see cref="Transaction"/>.
        /// </returns>
        Transaction AddTransaction(Transaction transaction);

        /// <summary>
        /// The confirm transaction.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="payerId">
        /// The payer id.
        /// </param>
        void ConfirmTransaction(string token, string payerId);

        /// <summary>
        /// The cancel transaction.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        void CancelTransaction(string token);

        /// <summary>
        /// The add package payment transaction.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// </returns>
        Tuple<Package, decimal> AddPackagePaymentTransaction(int packageId);
    }
}
