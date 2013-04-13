// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CountryConfiguration.cs" company="Naviam">
//   Vitali Hatalski. 2013.
// </copyright>
// <summary>
//   Defines the CountryConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Addresses;

    /// <summary>
    /// The country configuration.
    /// </summary>
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryConfiguration"/> class.
        /// </summary>
        public CountryConfiguration()
        {
            this.Property(c => c.Code).HasMaxLength(2).IsRequired();
        }
    }
}
