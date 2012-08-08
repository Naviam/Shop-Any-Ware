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
    /// <summary>
    /// The interface for package repository.
    /// </summary>
    public interface IPackageRepository
    {
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
        /// <param name="package">
        /// The package to add.
        /// </param>
        /// <returns>
        /// The added package.
        /// </returns>
        Package AddPackage(Package package);

        /// <summary>
        /// Remove package by ID.
        /// </summary>
        /// <param name="packageId">
        /// The package ID.
        /// </param>
        void RemovePackage(int packageId);

        /// <summary>
        /// Save changes to DB.
        /// </summary>
        void SaveChanges();
    }
}