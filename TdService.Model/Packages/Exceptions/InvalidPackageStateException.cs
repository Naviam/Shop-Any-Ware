// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidPackageStateException.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The invalid package state exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages.Exceptions
{
    using System;

    using TdService.Resources;

    /// <summary>
    /// The invalid package state exception.
    /// </summary>
    public class InvalidPackageStateException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPackageStateException"/> class.
        /// </summary>
        /// <param name="stateFrom">
        /// The state from.
        /// </param>
        /// <param name="stateTo">
        /// The state to.
        /// </param>
        public InvalidPackageStateException(PackageStatus stateFrom, PackageStatus stateTo)
            : base(
                string.Format(
                    PackageStatusResources.InvalidPackageStateException, stateFrom, stateTo))
        {
        }
    }
}
