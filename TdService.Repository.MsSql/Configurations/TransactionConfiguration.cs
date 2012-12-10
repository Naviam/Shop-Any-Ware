

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using TdService.Model.Balance;
    using TdService.Model.Common;

    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionConfiguration"/> class.
        /// </summary>
        public TransactionConfiguration()
        {
            this.Property(t => t.Token).HasMaxLength(30);
            this.Property(t =>t.PayerId).HasMaxLength(30);
        }
    }
}
