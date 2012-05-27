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
    /// This class describes the configuration of user db table.
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfiguration"/> class.
        /// </summary>
        public UserConfiguration()
        {
            this.Property(u => u.Password).IsRequired();
            this.Property(u => u.Password).HasMaxLength(20);
            this.Property(u => u.Email).IsRequired();
            this.Property(u => u.Email).HasMaxLength(256);
            this.Property(u => u.RowVersion).IsRowVersion();
        }
    }
}