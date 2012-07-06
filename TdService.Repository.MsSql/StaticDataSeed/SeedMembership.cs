// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedMembership.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Seed users and roles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.StaticDataSeed
{
    using System.Collections.Generic;
    using System.Data;

    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Membership;

    /// <summary>
    /// Seed users and roles.
    /// </summary>
    public static class SeedMembership
    {
        /// <summary>
        /// Populate users.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void Populate(ShopAnyWareSql context)
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
                Roles = new List<Role> { adminRole },
                Wallet = new Wallet { Amount = 1003.23m }
            };
            user = context.Users.Add(user);

            context.SaveChanges();

            user.DeliveryAddresses = new List<DeliveryAddress>
             {
                 new DeliveryAddress
                 {
                     AddressLine1 = "Novovilenskaya street",
                     AddressLine2 = "10, 41",
                     AddressLine3 = string.Empty,
                     AddressName = "Minsk - Novovilenskaya",
                     City = "Minsk",
                     Country = "Russia",
                     FirstName = "Vitali",
                     LastName = "Hatalski",
                     Phone = "+375295067630",
                     ZipCode = "220053"
                 }
             };

            context.Entry(user).State = EntityState.Modified;
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

            // oleg
            var user2 = new User
            {
                Email = "tdservice@mail.ru",
                Password = "1",
                Roles = new List<Role>(),
                Wallet = new Wallet { Amount = 988.00m }
            };
            user2.Roles.Add(adminRole);
            user2.Roles.Add(operatorRole);
            context.Users.Add(user2);
            context.SaveChanges();

            user2.Profile = new Profile
            {
                FirstName = "Oleg",
                LastName = "Voronin",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Entry(user2).State = EntityState.Modified;
            context.SaveChanges();

            // shopper
            var shopper = new User
            {
                Email = "shopper@shopanyware.ru",
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

            // operator
            var operatorUser = new User
            {
                Email = "operator@shopanyware.ru",
                Password = "1",
                Roles = new List<Role>(),
                Wallet = new Wallet { Amount = 0.00m }
            };
            operatorUser.Roles.Add(operatorRole);
            context.Users.Add(operatorUser);
            context.SaveChanges();

            operatorUser.Profile = new Profile
            {
                FirstName = "Operator Name",
                LastName = "Surname",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Entry(operatorUser).State = EntityState.Modified;
            context.SaveChanges();

            // consultant
            var consultant = new User
            {
                Email = "consultant@shopanyware.ru",
                Password = "1",
                Roles = new List<Role>(),
                Wallet = new Wallet { Amount = 0.00m }
            };
            consultant.Roles.Add(consultantRole);
            context.Users.Add(consultant);
            context.SaveChanges();

            consultant.Profile = new Profile
            {
                FirstName = "Consultant Name",
                LastName = "Surname",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Entry(consultant).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}