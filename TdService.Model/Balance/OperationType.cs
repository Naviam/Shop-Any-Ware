// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationType.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   Defines the OperationType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Balance
{
    /// <summary>
    /// The operation type.
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// The pay pal balance load.
        /// </summary>
        PayPalBalanceLoad = 0,

        /// <summary>
        /// The package payment.
        /// </summary>
        PackagePayment = 1
    }
}
