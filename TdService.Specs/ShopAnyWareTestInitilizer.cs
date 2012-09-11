// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopAnyWareTestInitilizer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Shop any ware db initilizer that drops and recreate database for running db tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Specs
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;

    using TdService.Model.Balance;
    using TdService.Model.Common;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.StaticDataSeed;

    /// <summary>
    /// Shop any ware db initilizer that drops and recreate database for running db tests.
    /// </summary>
    public class ShopAnyWareTestInitilizer : DropCreateDatabaseAlways<ShopAnyWareSql>
    {
        /// <summary>
        /// Populate database with static data.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(ShopAnyWareSql context)
        {
            var adminRole = new Role { Name = "Admin", Description = "System Administrator" };
            var shopperRole = new Role { Name = "Shopper", Description = "Main user of the system" };
            var operatorRole = new Role { Name = "Operator", Description = "Person who process orders" };
            var consultantRole = new Role { Name = "Consultant", Description = "Person who help user to solve service issues" };
            context.Roles.Add(adminRole);
            context.Roles.Add(shopperRole);
            context.Roles.Add(operatorRole);
            context.Roles.Add(consultantRole);

            context.SaveChanges();

            // vitali
            var profile = new Profile
            {
                FirstName = "Vitali",
                LastName = "Hatalski",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };

            context.Profiles.Add(profile);

            var user = new User
            {
                Email = "vhatalski@naviam.com",
                Password = "ruinruin",
                Profile = profile,
                Roles = new List<Role> { adminRole, shopperRole, operatorRole },
                Wallet = new Wallet { Amount = 1003.23m }
            };
            context.Users.Add(user);

            context.SaveChanges();

            // shopper
            var profile2 = new Profile
            {
                FirstName = "Shopper Name",
                LastName = "Surname",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Profiles.Add(profile2);

            var shopper = new User
            {
                Email = "v.hatalski@gmail.com",
                Password = "1111111111",
                Profile = profile2,
                Roles = new List<Role> { shopperRole },
                Wallet = new Wallet { Amount = 88.00m }
            };
            context.Users.Add(shopper);
            context.SaveChanges();
            
            //// SeedMembership.Populate(context);
            SeedCurrencies.Populate(context);

            //// SeedRetailers.Populate(context, new FileStorage());
            context.Retailers.Add(new Retailer("amazon.com"));
            context.Retailers.Add(new Retailer("apple.com"));
            context.SaveChanges();
            SeedOrders.Populate(context);
            SeedPackages.Populate(context);

            base.Seed(context);
        }
    }
}