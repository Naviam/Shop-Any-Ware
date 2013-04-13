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
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using TdService.Model.Packages;
    using TdService.Repository.MsSql.Extensions;

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
        /// The get package by id.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="Package"/>.
        /// </returns>
        public Package GetPackageById(int packageId)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Packages.Find(packageId);
            }
        }

        /// <summary>
        /// The update package.
        /// </summary>
        /// <param name="package">
        /// The package.
        /// </param>
        public void UpdatePackage(Package package)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Packages.Attach(package);
                context.Entry(package).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

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
        public List<Package> GetShoppersPackages(bool includeAssembling, bool includePaid, bool includeSent)
        {
            using (var context = new ShopAnyWareSql())
            {
                var statuses = new List<PackageStatus>();
                if (includeAssembling)
                {
                    statuses.Add(PackageStatus.Assembling);
                }

                if (includePaid)
                {
                    statuses.Add(PackageStatus.Paid);
                }

                if (includeSent)
                {
                    statuses.Add(PackageStatus.Sent);
                }

                if (!includeAssembling && !includePaid && !includeSent)
                {
                    return new List<Package>();
                }

                return
                    context.Packages.Include(p => p.Items)
                           .Include(p => p.User)
                           .Where(p => statuses.Contains(p.Status))
                           .ToList();
            }
        }
    }
}