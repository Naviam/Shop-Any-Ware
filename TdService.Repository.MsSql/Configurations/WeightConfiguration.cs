// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeightConfiguration.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The weight configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Common;

    /// <summary>
    /// The weight configuration.
    /// </summary>
    public class WeightConfiguration : EntityTypeConfiguration<Weight>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeightConfiguration"/> class.
        /// </summary>
        public WeightConfiguration()
        {
            this.Property(w => w.Pounds).IsOptional();
            this.Property(w => w.Ounces).IsOptional();
        }
    }
}