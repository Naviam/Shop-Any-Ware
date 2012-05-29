// -----------------------------------------------------------------------
// <copyright file="AddressBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// This class contains business rules for address entity.
    /// </summary>
    public class AddressBusinessRules
    {
        /// <summary>
        /// This rule ensures that address line 1 for address is set.
        /// </summary>
        public static readonly BusinessRule AddressLine1Required =
            new BusinessRule("AddressLine1", BusinessRules.Address_AddressLine1Required);

        /// <summary>
        /// This rule ensures that city for address is set.
        /// </summary>
        public static readonly BusinessRule CityRequired = 
            new BusinessRule("City", BusinessRules.Address_CityRequired);

        /// <summary>
        /// This rule ensures that country for address is set.
        /// </summary>
        public static readonly BusinessRule CountryRequired = 
            new BusinessRule("Country", BusinessRules.Address_CountryRequired);

        /// <summary>
        /// This rule ensures that zip code for address is set.
        /// </summary>
        public static readonly BusinessRule ZipCodeRequired = 
            new BusinessRule("ZipCode", BusinessRules.Address_ZipCodeRequired);
    }
}