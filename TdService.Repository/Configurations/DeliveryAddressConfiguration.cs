// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressConfiguration.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Data.SqlRepository.Configurations
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
            Property(a => a.AddressName).IsRequired();
            Property(a => a.AddressName).HasMaxLength(64);
            Property(a => a.Country).IsRequired();
            Property(a => a.Country).HasMaxLength(64);
            Property(a => a.City).IsRequired();
            Property(a => a.City).HasMaxLength(64);
            Property(a => a.State).HasMaxLength(64);
            Property(a => a.Region).HasMaxLength(64);
            Property(a => a.Address1).IsRequired();
            Property(a => a.Address1).HasMaxLength(256);
            Property(a => a.Address2).HasMaxLength(256);
            Property(a => a.Address3).HasMaxLength(256);
            Property(a => a.FirstName).IsRequired();
            Property(a => a.FirstName).HasMaxLength(64);
            Property(a => a.LastName).IsRequired();
            Property(a => a.LastName).HasMaxLength(64);
            Property(a => a.Phone).HasMaxLength(21);
            Property(a => a.RowVersion).IsRowVersion();
        }
    }
}