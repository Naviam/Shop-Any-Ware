// -----------------------------------------------------------------------
// <copyright file="ProfileConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Membership;

    /// <summary>
    /// This class describes the configuration of profile db table.
    /// </summary>
    public class ProfileConfiguration : EntityTypeConfiguration<Profile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileConfiguration"/> class.
        /// </summary>
        public ProfileConfiguration()
        {
            this.Property(p => p.FirstName).HasMaxLength(21).IsRequired();
            this.Property(p => p.LastName).HasMaxLength(21).IsRequired();
            this.Property(p => p.RowVersion).IsRowVersion();
        }
    }
}