// -----------------------------------------------------------------------
// <copyright file="UserConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Data.SqlRepository.Configurations
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
            Property(u => u.Password).IsRequired();
            Property(u => u.Password).HasMaxLength(20);
            Property(u => u.Email).IsRequired();
            Property(u => u.Email).HasMaxLength(256);
            Property(u => u.RowVersion).IsRowVersion();
        }
    }
}