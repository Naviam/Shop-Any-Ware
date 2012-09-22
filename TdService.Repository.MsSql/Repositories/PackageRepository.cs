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
    using System.Linq;

    using TdService.Model.Packages;

    /// <summary>
    /// The package repository.
    /// </summary>
    public class PackageRepository : IPackageRepository
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
        public Package GetPackageWithItemsById(int packageId)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Packages.Include("Items").SingleOrDefault(p => p.Id == packageId);
            }
        }

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
        public Package AddPackage(string email, Package package)
        {
            using (var context = new ShopAnyWareSql())
            {
                var packageAdded = context.Packages.Add(package);
                var user = context.Users.Include("Profile").Include("Roles").SingleOrDefault(u => u.Email == email);
                if (user != null)
                {
                    user.AddPackage(packageAdded);
                }

                context.SaveChanges();
                return packageAdded;
            }
        }

        /// <summary>
        /// Remove package by ID.
        /// </summary>
        /// <param name="packageId">
        /// The package ID.
        /// </param>
        public void RemovePackage(int packageId)
        {
            using (var context = new ShopAnyWareSql())
            {
                var package = context.Packages.Find(packageId);
                context.Packages.Remove(package);
            }
        }

        /// <summary>
        /// Save changes to DB.
        /// </summary>
        public void SaveChanges()
        {
            using (var context = new ShopAnyWareSql())
            {
                context.SaveChanges();
            }
        }
    }
}