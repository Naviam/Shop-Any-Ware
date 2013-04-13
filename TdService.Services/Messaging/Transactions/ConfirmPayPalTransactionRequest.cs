// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmPayPalTransactionRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The confirm pay pal transaction request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Transactions
{
    /// <summary>
    /// The confirm pay pal transaction request.
    /// </summary>
    public class ConfirmPayPalTransactionRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets payer id
        /// </summary>
        public string PayerId { get; set; }
    }
}
