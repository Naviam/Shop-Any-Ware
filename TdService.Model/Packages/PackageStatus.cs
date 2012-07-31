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
        /// New package
        /// </summary>
        New = 0,

        /// <summary>
        /// Pending payment.
        /// </summary>
        PendingPayment = 1,

        /// <summary>
        /// Ready to be dispatched.
        /// </summary>
        ReadyToDispatch = 2,

        /// <summary>
        /// Dispatched status.
        /// </summary>
        Dispatched = 3,

        /// <summary>
        /// Delivered status.
        /// </summary>
        Delivered = 4
    }
}