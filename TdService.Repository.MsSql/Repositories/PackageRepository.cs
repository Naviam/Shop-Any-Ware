// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;

    using TdService.Model.Packages;

    /// <summary>
    /// The package repository.
    /// </summary>
    public class PackageRepository : IPackageRepository, IDisposable
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public PackageRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add new package
        /// </summary>
        /// <param name="package">
        /// The package to add.
        /// </param>
        /// <returns>
        /// The added package.
        /// </returns>
        public Package AddPackage(Package package)
        {
            return this.context.Packages.Add(package);
        }

        /// <summary>
        /// Remove package by ID.
        /// </summary>
        /// <param name="packageId">
        /// The package ID.
        /// </param>
        public void RemovePackage(int packageId)
        {
            var package = this.context.Packages.Find(packageId);
            if (package != null)
            {
                this.context.Packages.Remove(package);
            }
        }

        /// <summary>
        /// Save changes to DB.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}