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

    using TdService.Model.Addresses;

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
            // role table
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Role>().Property(r => r.Name).HasMaxLength(64);
            modelBuilder.Entity<Role>().Property(r => r.Description).HasMaxLength(256);
            modelBuilder.Entity<Role>().Property(r => r.RowVersion).IsRowVersion();

            // user table
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(256);
            modelBuilder.Entity<User>().Property(u => u.RowVersion).IsRowVersion();

            // delivery address table
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.AddressName).IsRequired();
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.AddressName).HasMaxLength(64);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.Country).IsRequired();
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.Country).HasMaxLength(64);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.City).IsRequired();
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.City).HasMaxLength(64);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.State).HasMaxLength(64);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.Address1).IsRequired();
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.Address1).HasMaxLength(256);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.Address2).HasMaxLength(256);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.Address3).HasMaxLength(256);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.FirstName).IsRequired();
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.FirstName).HasMaxLength(64);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.LastName).IsRequired();
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.LastName).HasMaxLength(64);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.Phone).HasMaxLength(21);
            modelBuilder.Entity<DeliveryAddress>().Property(a => a.RowVersion).IsRowVersion();
        }
    }
}