// -----------------------------------------------------------------------
// <copyright file="CurrencyConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Balance;

    /// <summary>
    /// This class describes the configuration of currency db table.
    /// </summary>
    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyConfiguration"/> class.
        /// </summary>
        public CurrencyConfiguration()
        {
            this.Property(c => c.Name).HasMaxLength(64);
            this.Property(c => c.Entity).HasMaxLength(64);
            this.Property(c => c.AlphabeticCode).IsRequired().IsFixedLength().HasMaxLength(3);
            this.Property(c => c.NumericCode).IsRequired().IsFixedLength().HasMaxLength(3);
        }
    }
}