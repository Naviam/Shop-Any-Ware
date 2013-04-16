// -----------------------------------------------------------------------
// <copyright file="UserConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Membership;

    /// <summary>
    /// This class describes the configuration of user DB table.
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfiguration"/> class.
        /// </summary>
        public UserConfiguration()
        {
            this.Property(u => u.Password).IsRequired().HasMaxLength(100);
            this.Property(u => u.Email).IsRequired().HasMaxLength(256);
            this.Property(u => u.RowVersion).IsRowVersion();
            this.Property(u => u.LastAccessDate).IsOptional();
        }
    }
}