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
    using System.Data.Entity;
    using TdService.Repository.MsSql.Extensions;
    using TdService.Model.Membership;

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
                return context.PackagesWithItemsAndImages().SingleOrDefault(p => p.Id == packageId);
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
                var user = context.Users.Include(u => u.Profile).Include(u => u.Roles).Include(u => u.Wallet).SingleOrDefault(u => u.Email == email);
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
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get Package By Id
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public Package GetPackageById(int packageId)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Packages.Find(packageId);
            }
        }


        public void UpdatePackage(Package package)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Packages.Attach(package);
                context.Entry<Package>(package).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}