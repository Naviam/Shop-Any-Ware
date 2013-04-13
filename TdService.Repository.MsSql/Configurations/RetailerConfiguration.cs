// -----------------------------------------------------------------------
// <copyright file="RetailerConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Orders;

    /// <summary>
    /// This class describes the configuration of retailers DB table.
    /// </summary>
    public class RetailerConfiguration : EntityTypeConfiguration<Retailer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetailerConfiguration"/> class.
        /// </summary>
        public RetailerConfiguration()
        {
            this.Property(r => r.Name).HasMaxLength(256);
            this.Property(r => r.Category).HasMaxLength(256);
            this.Property(r => r.Url).IsRequired().HasMaxLength(256);
            this.Property(r => r.Description).HasMaxLength(1000);
        }
    }
}