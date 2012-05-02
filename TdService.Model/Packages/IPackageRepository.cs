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
    using Orders;

    /// <summary>
    /// The interface for package repository.
    /// </summary>
    public interface IPackageRepository
    {
        /// <summary>
        /// Add orders to package
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="orders">
        /// The orders.
        /// </param>
        void AddOrdersToPackage(int packageId, IEnumerable<Order> orders);

        /// <summary>
        /// Remove package
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        void RemovePackage(int packageId);

        /// <summary>
        /// Get my packages
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="sortDirection">
        /// The sort direction.
        /// </param>
        /// <param name="sortExpression">
        /// The sort expression.
        /// </param>
        /// <param name="filterExpression">
        /// The filter expression.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// Collection of packages
        /// </returns>
        IEnumerable<Package> GetMyPackages(string username, object sortDirection, string sortExpression, string filterExpression, int pageSize);

        /// <summary>
        /// Get all packages
        /// </summary>
        /// <param name="sortDirection">
        /// The sort direction.
        /// </param>
        /// <param name="sortExpression">
        /// The sort expression.
        /// </param>
        /// <param name="filterExpression">
        /// The filter expression.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// Collection of packages.
        /// </returns>
        IEnumerable<Package> GetPackages(object sortDirection, string sortExpression, string filterExpression, int pageSize = 20);

        /// <summary>
        /// Get package details.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// Package details.
        /// </returns>
        Package GetPackageDetails(int packageId);

        /// <summary>
        /// Update package.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        void UpdatePackage(Package package);

        /// <summary>
        /// Update package status.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <param name="newStatus">
        /// The new status.
        /// </param>
        void UpdatePackageStatus(int packageId, PackageStatus newStatus);

        /// <summary>
        /// Adds new parcel and returns parcel id
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="package">
        /// The package.
        /// </param>
        /// <returns>
        /// The added parcel id.
        /// </returns>
        int AddParcel(string username, Package package);
    }
}