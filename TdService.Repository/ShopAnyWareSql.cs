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
        /// Model creating rules.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().IsFixedLength().HasMaxLength(50);
        }
    }
}