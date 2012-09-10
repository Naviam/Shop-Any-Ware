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
            var user = new User
            {
                Email = "vhatalski@naviam.com",
                Password = "ruinruin",
                Roles = new List<Role> { adminRole, shopperRole, operatorRole },
                Wallet = new Wallet { Amount = 1003.23m }
            };
            user = context.Users.Add(user);

            context.SaveChanges();

            user.Profile = new Profile
            {
                FirstName = "Vitali",
                LastName = "Hatalski",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();

            // shopper
            var shopper = new User
            {
                Email = "v.hatalski@gmail.com",
                Password = "1",
                Roles = new List<Role>(),
                Wallet = new Wallet { Amount = 88.00m }
            };
            shopper.Roles.Add(shopperRole);
            context.Users.Add(shopper);
            context.SaveChanges();

            shopper.Profile = new Profile
            {
                FirstName = "Shopper Name",
                LastName = "Surname",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Entry(shopper).State = EntityState.Modified;
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