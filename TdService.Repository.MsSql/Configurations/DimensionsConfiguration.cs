// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DimensionsConfiguration.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The dimensions configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Common;

    /// <summary>
    /// The dimensions configuration.
    /// </summary>
    public class DimensionsConfiguration : EntityTypeConfiguration<Dimensions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DimensionsConfiguration"/> class.
        /// </summary>
        public DimensionsConfiguration()
        {
            this.Property(d => d.Girth).IsOptional();
            this.Property(d => d.Length).IsOptional();
            this.Property(d => d.Width).IsOptional();
            this.Property(d => d.Height).IsOptional();
        }
    }
}