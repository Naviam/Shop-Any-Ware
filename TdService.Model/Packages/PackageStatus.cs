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
        /// The assembling.
        /// </summary>
        Assembling = 1,

        /// <summary>
        /// The assembled.
        /// </summary>
        Assembled = 2,

        /// <summary>
        /// The paid.
        /// </summary>
        Paid = 3,

        /// <summary>
        /// The sent.
        /// </summary>
        Sent = 4,

        /// <summary>
        /// Delivered status.
        /// </summary>
        Delivered = 5
    }
}