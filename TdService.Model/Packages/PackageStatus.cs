// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageStatus.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the PackageStatus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages
{
    /// <summary>
    /// Status of the package.
    /// </summary>
    public enum PackageStatus
    {
        /// <summary>
        /// Pending payment
        /// </summary>
        PendingPayment = 0,

        /// <summary>
        /// In progress
        /// </summary>
        Processing = 3,

        /// <summary>
        /// Paid status
        /// </summary>
        Paid = 1,

        /// <summary>
        /// Collected status
        /// </summary>
        Collected,

        /// <summary>
        /// Dispatched status
        /// </summary>
        Dispatched,
    }
}