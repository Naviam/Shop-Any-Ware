// -----------------------------------------------------------------------
// <copyright file="RetailerConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Data.SqlRepository.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model;

    /// <summary>
    /// This class describes the configuration of retailers db table.
    /// </summary>
    public class RetailerConfiguration : EntityTypeConfiguration<Retailer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetailerConfiguration"/> class.
        /// </summary>
        public RetailerConfiguration()
        {
            Property(r => r.Name).IsRequired().HasMaxLength(64);
            Property(r => r.Category).IsRequired().HasMaxLength(64);
        }
    }
}