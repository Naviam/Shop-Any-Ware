// -----------------------------------------------------------------------
// <copyright file="AddressBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// This class contains business rules for address entity.
    /// </summary>
    public class AddressBusinessRules
    {
        /// <summary>
        /// This rule ensures that address line 1 for address is set.
        /// </summary>
        public static readonly BusinessRule AddressLine1Required =
            new BusinessRule("AddressLine1", ErrorCode.AddressAddressLine1Required.ToString());

        /// <summary>
        /// The address line 1 max length.
        /// </summary>
        public static readonly BusinessRule AddressLine1MaxLength =
            new BusinessRule("AddressLine1", ErrorCode.AddressAddressLine1Required.ToString());

        /// <summary>
        /// The address line 2 max length.
        /// </summary>
        public static readonly BusinessRule AddressLine2MaxLength =
            new BusinessRule("AddressLine2", ErrorCode.AddressAddressLine2MaxLength.ToString());

        /// <summary>
        /// This rule ensures that city for address is set.
        /// </summary>
        public static readonly BusinessRule CityRequired =
            new BusinessRule("City", ErrorCode.AddressCityRequired.ToString());

        /// <summary>
        /// This rule ensures that country for address is set.
        /// </summary>
        public static readonly BusinessRule CountryRequired =
            new BusinessRule("Country", ErrorCode.AddressCountryRequired.ToString());

        /// <summary>
        /// This rule ensures that zip code for address is set.
        /// </summary>
        public static readonly BusinessRule ZipCodeRequired =
            new BusinessRule("ZipCode", ErrorCode.AddressZipCodeRequired.ToString());

        /// <summary>
        /// The zip code max length.
        /// </summary>
        public static readonly BusinessRule ZipCodeMaxLength =
            new BusinessRule("ZipCode", ErrorCode.AddressZipCodeMaxLength.ToString());

        /// <summary>
        /// The city max length.
        /// </summary>
        public static readonly BusinessRule CityMaxLength =
            new BusinessRule("City", ErrorCode.AddressCityMaxLength.ToString());

        /// <summary>
        /// The country max length.
        /// </summary>
        public static readonly BusinessRule CountryMaxLength =
            new BusinessRule("Country", ErrorCode.AddressCountryMaxLength.ToString());

        /// <summary>
        /// The phone max length.
        /// </summary>
        public static readonly BusinessRule PhoneMaxLength =
            new BusinessRule("Phone", ErrorCode.AddressPhoneMaxLength.ToString());

        /// <summary>
        /// The state max length.
        /// </summary>
        public static readonly BusinessRule StateMaxLength =
            new BusinessRule("State", ErrorCode.AddressStateMaxLength.ToString());

        /// <summary>
        /// The region max length.
        /// </summary>
        public static readonly BusinessRule RegionMaxLength =
            new BusinessRule("Region", ErrorCode.AddressRegionMaxLength.ToString());
    }
}