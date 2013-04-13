// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPackageRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IPackageRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages
{
    using System.Collections.Generic;

    /// <summary>
    /// The interface for package repository.
    /// </summary>
    public interface IPackageRepository
    {
        /// <summary>
        /// The get package by id.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="Package"/>.
        /// </returns>
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
        /// The update package.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        void UpdatePackage(Package package);

        /// <summary>
        /// The get shoppers packages.
        /// </summary>
        /// <param name="includeAssembling">
        /// The include assembling.
        /// </param>
        /// <param name="includePaid">
        /// The include paid.
        /// </param>
        /// <param name="includeSent">
        /// The include sent.
        /// </param>
        /// <returns>
        /// The collection of packages.
        /// </returns>
        List<Package> GetShoppersPackages(bool includeAssembling, bool includePaid, bool includeSent);
    }
}