// -----------------------------------------------------------------------
// <copyright file="RoleConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Membership;

    /// <summary>
    /// This class describes the configuration of role DB table.
    /// </summary>
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleConfiguration"/> class.
        /// </summary>
        public RoleConfiguration()
        {
            this.Property(r => r.Name).IsRequired();
            this.Property(r => r.Name).HasMaxLength(64);
            this.Property(r => r.Description).HasMaxLength(256);
            this.Property(r => r.RowVersion).IsRowVersion();
        }
    }
}