// -----------------------------------------------------------------------
// <copyright file="ShopAnyWareSql.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Data.SqlRepository
{
    using System.Data.Entity;
    using Model;
    using Model.Items;
    using Model.Membership;
    using Model.Orders;
    using Model.Packages;

    using TdService.Data.SqlRepository.Configurations;
    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Notification;

    /// <summary>
    /// DbContext for the entity framework mapping.
    /// </summary>
    public class ShopAnyWareSql : DbContext
    {
        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets Orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets Packages.
        /// </summary>
        public DbSet<Package> Packages { get; set; }

        /// <summary>
        /// Gets or sets Retailers.
        /// </summary>
        public DbSet<Retailer> Retailers { get; set; }

        /// <summary>
        /// Gets or sets Whallets.
        /// </summary>
        public DbSet<Wallet> Wallets { get; set; }

        /// <summary>
        /// Gets or sets Transactions.
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Gets or sets Currencies.
        /// </summary>
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets Roles.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets Profiles.
        /// </summary>
        public DbSet<Profile> Profiles { get; set; }

        /// <summary>
        /// Gets or sets Notification Rules.
        /// </summary>
        public DbSet<NotificationRule> NotificationRules { get; set; }

        /// <summary>
        /// Gets or sets Delivery Addresses.
        /// </summary>
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }

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
        }
    }
}