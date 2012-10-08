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
    using TdService.Model.Items;
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
                                CreatedDate = DateTime.UtcNow
                            },
                        new Package
                            {
                                Name = "Моя вторая посылка",
                                CreatedDate = DateTime.UtcNow.AddDays(-5)
                            }
                    };
            }

            context.SaveChanges();

            var item = new Item { Name = "Apple IPad", Color = "White", Quantity = 1, Price = 680m, Dimensions = new Dimensions { Width = 4, Height = 3, Length = 5, Girth = 4 }, Weight = new Weight { Pounds = 2, Ounces = 10 } };
            var newItem = context.Items.Add(item);

            context.SaveChanges();

            if (user != null)
            {
                var firstOrDefault = user.Packages.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    var package = context.Packages.Find(firstOrDefault.Id);
                    if (package.Items == null)
                    {
                        package.Items = new List<Item>();
                    }

                    package.Items.Add(newItem);
                }
            }

            context.SaveChanges();
        }
    }
}