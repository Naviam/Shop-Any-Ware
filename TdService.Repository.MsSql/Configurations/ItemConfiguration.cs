// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemConfiguration.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The item configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Items;

    /// <summary>
    /// The item configuration.
    /// </summary>
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemConfiguration"/> class.
        /// </summary>
        public ItemConfiguration()
        {
            this.Property(i => i.Name).IsRequired().HasMaxLength(64);
            this.Property(i => i.Color).HasMaxLength(64);
            this.Property(i => i.Size).HasMaxLength(64);
        }
    }
}