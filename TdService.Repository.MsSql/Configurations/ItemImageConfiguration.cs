// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemImageConfiguration.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   Defines the ItemImageConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Items;

    /// <summary>
    /// The item image configuration.
    /// </summary>
    public class ItemImageConfiguration : EntityTypeConfiguration<ItemImage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemImageConfiguration"/> class.
        /// </summary>
        public ItemImageConfiguration()
        {
            this.Property(p => p.Url).IsRequired().HasMaxLength(100);
            this.Property(p => p.Filename).HasMaxLength(64);
        }
    }
}
