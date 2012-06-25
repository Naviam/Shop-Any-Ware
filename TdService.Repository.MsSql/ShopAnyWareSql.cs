// -----------------------------------------------------------------------
// <copyright file="ShopAnyWareSql.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;

    using Configurations;

    using TdService.Model;
    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;

    /// <summary>
    /// DbContext for the entity framework mapping.
    /// </summary>
    public class ShopAnyWareSql : DbContext
    {
        /// <summary>
        /// Gets Items.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Item> Items { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Orders.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Order> Orders { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Packages.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Package> Packages { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Retailers.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Retailer> Retailers { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Whallets.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Wallet> Wallets { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Transactions.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Transaction> Transactions { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Currencies.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Currency> Currencies { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Users.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<User> Users { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Roles.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Role> Roles { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Profiles.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Profile> Profiles { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets Delivery Addresses.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Model creating rules.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new DeliveryAddressConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new RetailerConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new PackageConfiguration());
        }

        /// <summary>
        /// This initializer is used to populate database with static data.
        /// </summary>
        public class ShowAnyWareInitializer : DropCreateDatabaseAlways<ShopAnyWareSql>
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

                context.Retailers.Add(new Retailer { Category = "Computers", Name = "Apple, Inc.", Url = "apple.com", Description = "Apple Computers" });
                context.Retailers.Add(new Retailer { Category = "Computers", Name = "Amazon.com", Description = "Apple Computers" });
                context.Retailers.Add(new Retailer { Category = "Computers", Name = "Apple, Inc.", Description = "Apple Computers" });
                context.Retailers.Add(new Retailer { Category = "Computers", Name = "Apple, Inc.", Description = "Apple Computers" });
                context.Retailers.Add(new Retailer { Category = "Computers", Name = "Apple, Inc.", Description = "Apple Computers" });
                context.Retailers.Add(new Retailer { Category = "Computers", Name = "Apple, Inc.", Description = "Apple Computers" });
                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}