// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionConfiguration.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The transaction configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using TdService.Model.Balance;

    /// <summary>
    /// The transaction configuration.
    /// </summary>
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionConfiguration"/> class.
        /// </summary>
        public TransactionConfiguration()
        {
            this.Property(t => t.Token).HasMaxLength(30);
            this.Property(t => t.PayerId).HasMaxLength(30);
        }
    }
}
