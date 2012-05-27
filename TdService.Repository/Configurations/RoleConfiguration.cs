// -----------------------------------------------------------------------
// <copyright file="RoleConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Data.SqlRepository.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Membership;

    /// <summary>
    /// This class describes the configuration of role db table.
    /// </summary>
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleConfiguration"/> class.
        /// </summary>
        public RoleConfiguration()
        {
            Property(r => r.Name).IsRequired();
            Property(r => r.Name).HasMaxLength(64);
            Property(r => r.Description).HasMaxLength(256);
            Property(r => r.RowVersion).IsRowVersion();
        }
    }
}