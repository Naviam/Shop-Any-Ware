// -----------------------------------------------------------------------
// <copyright file="TdServiceContext.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService
{
    using System;
    using System.Data.Entity;
    using Model.Items;
    using Model.Orders;
    using Model.Packages;
    using Model.Shoppers;

    /// <summary>
    /// DbContext for the entity framework mapping.
    /// </summary>
    public class TdServiceContext : DbContext, IDisposable
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
        /// Gets or sets Parcels.
        /// </summary>
        public DbSet<Parcel> Parcels { get; set; }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}