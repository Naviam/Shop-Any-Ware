﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageState.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The PackageState interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages
{
    /// <summary>
    /// The Package State interface.
    /// </summary>
    public interface IPackageState
    {
        /// <summary>
        /// Gets a value indicating whether package can be modified.
        /// </summary>
        bool CanBeModified { get; }

        /// <summary>
        /// Gets a value indicating whether package items can be modified.
        /// </summary>
        bool CanItemsBeModified { get; }

        /// <summary>
        /// Gets a value indicating whether package can be sent.
        /// </summary>
        bool CanBeSent { get; }

        /// <summary>
        /// Gets a value indicating whether package can be removed.
        /// </summary>
        bool CanBeRemoved { get; }

        /// <summary>
        /// Gets a value indicating whether package can be disposed.
        /// </summary>
        bool CanBeDisposed { get; }
    }
}