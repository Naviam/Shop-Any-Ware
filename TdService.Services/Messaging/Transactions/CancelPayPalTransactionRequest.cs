// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CancelPayPalTransactionRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The cancel pay pal transaction request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Transactions
{
    /// <summary>
    /// The cancel pay pal transaction request.
    /// </summary>
    public class CancelPayPalTransactionRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; }
    }
}
