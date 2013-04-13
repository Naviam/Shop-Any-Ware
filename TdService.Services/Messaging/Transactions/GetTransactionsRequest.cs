// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetTransactionsRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get transactions request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Transactions
{
    /// <summary>
    /// The get transactions request.
    /// </summary>
    public class GetTransactionsRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the take.
        /// </summary>
        public int Take { get; set; }
    }
}
