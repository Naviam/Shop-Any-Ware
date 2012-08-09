// -----------------------------------------------------------------------
// <copyright file="ShopAnyWareSql.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql
{
    using System.Data.Entity;

    using Configurations;

    using TdService.Infrastructure.FileSystem;
    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;
    using TdService.Repository.MsSql.StaticDataSeed;

    /// <summary>
    /// DbContext for the entity framework mapping.
    /// </summary>
    public class ShopAnyWareSql : DbContext
    {
        /// <summary>
        /// Gets or sets Items.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Item> Items { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Orders.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Order> Orders { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Packages.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Package> Packages { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Retailers.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Retailer> Retailers { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Whallets.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Wallet> Wallets { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Transactions.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Transaction> Transactions { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Currencies.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Currency> Currencies { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<User> Users { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Role> Roles { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Profiles.
        /// </summary>
// ReSharper disable UnusedAutoPropertyAccessor.Local
        public DbSet<Profile> Profiles { get; set; }
// ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        /// Gets or sets Delivery Addresses.
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
            modelBuilder.Configurations.Add(new ItemConfiguration());
        }

        /// <summary>
        /// This initializer is used to populate database with static data.
        /// </summary>
        public class ShowAnyWareInitializer : DropCreateDatabaseIfModelChanges<ShopAnyWareSql>
        {
            /// <summary>
            /// Populate database with static data.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            protected override void Seed(ShopAnyWareSql context)
            {
                context.Database.ExecuteSqlCommand("ALTER TABLE Retailers ADD CONSTRAINT rc_Url UNIQUE(Url)");
                SeedMembership.Populate(context);
                SeedCurrencies.Populate(context);
                SeedRetailers.Populate(context, new FileWebStorage());
                SeedOrders.Populate(context);
                SeedPackages.Populate(context);

                base.Seed(context);
            }
        }
    }
}