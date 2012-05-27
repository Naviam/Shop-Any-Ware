// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wallet.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Stores total amount user has available to pay for the services
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Balance
{
    using System;
    using System.Collections.Generic;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// Stores total amount user has available to pay for the services
    /// </summary>
    public class Wallet : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets Transactions.
        /// </summary>
        public List<Transaction> Transactions { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}