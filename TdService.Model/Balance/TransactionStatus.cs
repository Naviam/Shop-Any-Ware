﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionStatus.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The status of the wire transaction
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Balance
{
    /// <summary>
    /// The status of the wire transaction.
    /// </summary>
    public enum TransactionStatus
    {
        /// <summary>
        /// Pending status.
        /// </summary>
        Pending,

        /// <summary>
        /// Approved status.
        /// </summary>
        Approved
    }
}