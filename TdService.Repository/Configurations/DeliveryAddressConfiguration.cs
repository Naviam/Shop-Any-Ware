// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using TdService.Model.Addresses;

    /// <summary>
    /// This class describes the configuration of deliveryaddresses db table.
    /// </summary>
    public class DeliveryAddressConfiguration : EntityTypeConfiguration<DeliveryAddress>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryAddressConfiguration"/> class.
        /// </summary>
        public DeliveryAddressConfiguration()
        {
            this.Property(a => a.AddressName).IsRequired();
            this.Property(a => a.AddressName).HasMaxLength(64);
            this.Property(a => a.Country).IsRequired();
            this.Property(a => a.Country).HasMaxLength(64);
            this.Property(a => a.City).IsRequired();
            this.Property(a => a.City).HasMaxLength(64);
            this.Property(a => a.State).HasMaxLength(64);
            this.Property(a => a.Region).HasMaxLength(64);
            this.Property(a => a.Address1).IsRequired();
            this.Property(a => a.Address1).HasMaxLength(256);
            this.Property(a => a.Address2).HasMaxLength(256);
            this.Property(a => a.Address3).HasMaxLength(256);
            this.Property(a => a.FirstName).IsRequired();
            this.Property(a => a.FirstName).HasMaxLength(64);
            this.Property(a => a.LastName).IsRequired();
            this.Property(a => a.LastName).HasMaxLength(64);
            this.Property(a => a.Phone).HasMaxLength(21);
            this.Property(a => a.RowVersion).IsRowVersion();
        }
    }
}