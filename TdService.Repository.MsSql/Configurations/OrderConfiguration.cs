// -----------------------------------------------------------------------
// <copyright file="OrderConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Orders;

    /// <summary>
    /// Database configuration for orders.
    /// </summary>
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderConfiguration"/> class.
        /// </summary>
        public OrderConfiguration()
        {
            this.Property(o => o.OrderNumber).HasMaxLength(64);
            this.Property(o => o.StatusExtended).HasMaxLength(64);
            this.Property(o => o.TrackingNumber).HasMaxLength(64);
        }
    }
}