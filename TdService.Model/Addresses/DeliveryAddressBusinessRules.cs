// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// This class contains business rules for delivery address entity.
    /// </summary>
    public class DeliveryAddressBusinessRules
    {
        /// <summary>
        /// This rule ensures that user's address name for delivery address is set.
        /// </summary>
        public static readonly BusinessRule AddressNameRequired = 
            new BusinessRule("AddressName", ErrorCode.DeliveryAddressAddressNameRequired.ToString());

        /// <summary>
        /// The address name max length.
        /// </summary>
        public static readonly BusinessRule AddressNameMaxLength =
            new BusinessRule("AddressName", ErrorCode.DeliveryAddressAddressNameMaxLength.ToString());

        /// <summary>
        /// This rule ensures that user's address name for delivery address is set.
        /// </summary>
        public static readonly BusinessRule FirstNameRequired =
            new BusinessRule("FirstName", ErrorCode.DeliveryAddressFirstNameRequired.ToString());

        /// <summary>
        /// The first name max length rule.
        /// </summary>
        public static readonly BusinessRule FirstNameMaxLength =
            new BusinessRule("FirstName", ErrorCode.DeliveryAddressFirstNameMaxLength.ToString());

        /// <summary>
        /// This rule ensures that user's address name for delivery address is set.
        /// </summary>
        public static readonly BusinessRule LastNameRequired =
            new BusinessRule("LastName", ErrorCode.DeliveryAddressLastNameRequired.ToString());

        /// <summary>
        /// The last name max length rule.
        /// </summary>
        public static readonly BusinessRule LastNameMaxLength =
            new BusinessRule("LastName", ErrorCode.DeliveryAddressLastNameMaxLength.ToString());
    }
}
