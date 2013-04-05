// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Address type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// This is a base class for address information.
    /// </summary>
    public class Address : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets Zip.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the country 1.
        /// </summary>
        public Country Country1 { get; set; }

        /// <summary>
        /// Gets or sets Region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Address Line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets Address Line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets Address Line 3.
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Validate business rules against this entity.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.AddressLine1))
            {
                this.AddBrokenRule(AddressBusinessRules.AddressLine1Required);
            }
            else if (this.AddressLine1.Length > 256)
            {
                this.AddBrokenRule(AddressBusinessRules.AddressLine1MaxLength);
            }

            if (this.AddressLine2.Length > 256)
            {
                this.AddBrokenRule(AddressBusinessRules.AddressLine2MaxLength);
            }

            if (string.IsNullOrEmpty(this.ZipCode))
            {
                this.AddBrokenRule(AddressBusinessRules.ZipCodeRequired);
            }
            else if (this.ZipCode.Length > 10)
            {
                this.AddBrokenRule(AddressBusinessRules.ZipCodeMaxLength);
            }

            if (string.IsNullOrEmpty(this.City))
            {
                this.AddBrokenRule(AddressBusinessRules.CityRequired);
            }
            else if (this.City.Length > 64)
            {
                this.AddBrokenRule(AddressBusinessRules.CityMaxLength);
            }

            if (string.IsNullOrEmpty(this.Country))
            {
                this.AddBrokenRule(AddressBusinessRules.CountryRequired);
            }
            else if (this.Country.Length > 64)
            {
                this.AddBrokenRule(AddressBusinessRules.CountryMaxLength);
            }

            if (!string.IsNullOrEmpty(this.Phone) && this.Phone.Length > 21)
            {
                this.AddBrokenRule(AddressBusinessRules.PhoneMaxLength);
            }

            if (!string.IsNullOrEmpty(this.State) && this.State.Length > 64)
            {
                this.AddBrokenRule(AddressBusinessRules.StateMaxLength);
            }

            if (!string.IsNullOrEmpty(this.Region) && this.Region.Length > 64)
            {
                this.AddBrokenRule(AddressBusinessRules.RegionMaxLength);
            }
        }
    }
}