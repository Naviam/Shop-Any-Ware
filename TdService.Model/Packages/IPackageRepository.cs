// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IPackageRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using TdService.Model.Membership;
namespace TdService.Model.Packages
{
    /// <summary>
    /// The interface for package repository.
    /// </summary>
    public interface IPackageRepository
    {
        /// <summary>
        ///  Get package by Id.
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        Package GetPackageById(int packageId);

        /// <summary>
        /// Get package with items by Id.
        /// </summary>
        /// <param name="packageId">
        /// The package Id.
        /// </param>
        /// <returns>
        /// The package.
        /// </returns>
        Package GetPackageWithItemsById(int packageId);

        /// <summary>
        /// Add new package
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="package">
        /// The package to add.
        /// </param>
        /// <returns>
        /// The added package.
        /// </returns>
        Package AddPackage(string email, Package package);

        /// <summary>
        /// Remove package by ID.
        /// </summary>
        /// <param name="packageId">
        /// The package ID.
        /// </param>
        void RemovePackage(int packageId);

        /// <summary>
        /// Updates package
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        void UpdatePackage(Package package);

        List<Package> GetShoppersPackages(bool includeAssebling, bool includePaid, bool includeSent);
    }
}