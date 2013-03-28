// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedPackages.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The seed orders.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.StaticDataSeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TdService.Model.Common;
    using TdService.Model.Packages;

    /// <summary>
    /// The seed orders.
    /// </summary>
    public static class SeedPackages
    {
        /// <summary>
        /// Populate database with few orders.
        /// </summary>
        /// <param name="context">
        /// Shop any ware context.
        /// </param>
        public static void Populate(ShopAnyWareSql context)
        {
            var user = context.Users.SingleOrDefault(u => u.Email == "vhatalski@naviam.com");
            if (user != null)
            {
                user.Packages = new List<Package>
                    {
                        new Package
                            {
                                Name = "Моя первая посылка",
                                Dimensions = new Dimensions(),
                                CreatedDate = DateTime.UtcNow
                            },
                        new Package
                            {
                                Name = "Моя вторая посылка",
                                Dimensions = new Dimensions(),
                                CreatedDate = DateTime.UtcNow.AddDays(-5)
                            }
                    };
            }

            context.SaveChanges();
        }
    }
}