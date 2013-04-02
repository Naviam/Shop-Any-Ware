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

        Assembling = 1,

        Assembled = 2,

        Paid = 3,

        Sent = 4,

        /// <summary>
        /// Delivered status.
        /// </summary>
        Delivered = 5

    }
}