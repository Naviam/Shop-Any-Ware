// -----------------------------------------------------------------------
// <copyright file="PackageConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Packages;

    /// <summary>
    /// Database configuration for packages.
    /// </summary>
    public class PackageConfiguration : EntityTypeConfiguration<Package>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageConfiguration"/> class.
        /// </summary>
        public PackageConfiguration()
        {
            this.Property(p => p.Name).HasMaxLength(21);
            this.HasMany(p => p.Items).WithOptional(i => i.Package).HasForeignKey(i => i.PackageId).WillCascadeOnDelete(true);
            //this.HasOptional(p => p.DeliveryAddress).WithMany();
        }
    }
}