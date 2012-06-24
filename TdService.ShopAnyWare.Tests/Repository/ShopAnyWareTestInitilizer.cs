// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopAnyWareTestInitilizer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Shop any ware db initilizer that drops and recreate database for running db tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Repository
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;

    using TdService.Model;
    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Membership;
    using TdService.Repository.MsSql;

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
            var consultantRole = new Role
            {
                Name = "Consultant",
                Description = "Person who help user to solve service issues"
            };
            context.Roles.Add(adminRole);
            context.Roles.Add(shopperRole);
            context.Roles.Add(operatorRole);
            context.Roles.Add(consultantRole);

            context.SaveChanges();

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

            var user2 = new User
                {
                    Email = "tdservice@mail.ru",
                    Password = "1",
                    Roles = new List<Role>()
                };
            user2.Roles.Add(adminRole);
            user2.Roles.Add(operatorRole);
            user2.Profile = new Profile
                {
                    FirstName = "Oleg",
                    LastName = "Voronin",
                    NotifyOnOrderStatusChanged = true,
                    NotifyOnPackageStatusChanged = true
                };
            context.Users.Add(user2);

            var shopper = new User
                {
                    Email = "shopper@shopanyware.ru",
                    Password = "1",
                    Roles = new List<Role>()
                };
            shopper.Profile = new Profile
                {
                    FirstName = "Shopper Name",
                    LastName = "Surname",
                    NotifyOnOrderStatusChanged = true,
                    NotifyOnPackageStatusChanged = true
                };
            shopper.Roles.Add(shopperRole);
            context.Users.Add(shopper);

            var operatorUser = new User
            {
                Email = "operator@shopanyware.ru",
                Password = "1",
                Roles = new List<Role>()
            };
            operatorUser.Roles.Add(operatorRole);
            operatorUser.Profile = new Profile
            {
                FirstName = "Operator Name",
                LastName = "Surname",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Users.Add(operatorUser);

            var consultant = new User
            {
                Email = "consultant@shopanyware.ru",
                Password = "1",
                Roles = new List<Role>()
            };
            consultant.Roles.Add(consultantRole);
            consultant.Profile = new Profile
            {
                FirstName = "Consultant Name",
                LastName = "Surname",
                NotifyOnOrderStatusChanged = true,
                NotifyOnPackageStatusChanged = true
            };
            context.Users.Add(consultant);

            context.SaveChanges();

            context.Currencies.Add(
                new Currency
                {
                    AlphabeticCode = "USD",
                    Entity = "UNITED STATES",
                    Name = "US Dollar",
                    NumericCode = "840",
                    MinorUnit = 2
                });
            context.Currencies.Add(
                new Currency
                {
                    AlphabeticCode = "EUR",
                    Entity = "Europa",
                    Name = "Euro",
                    NumericCode = "978",
                    MinorUnit = 2
                });
            context.Currencies.Add(
                new Currency
                {
                    AlphabeticCode = "RUB",
                    Entity = "RUSSIAN FEDERATION",
                    Name = "Russian Ruble",
                    NumericCode = "643",
                    MinorUnit = 2
                });

            context.SaveChanges();

            context.Retailers.Add(
                new Retailer { Category = "Computers", Name = "Apple, Inc.", Description = "Apple Computers" });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}