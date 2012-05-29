// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// This class contains business rules for delivery address entity.
    /// </summary>
    public class DeliveryAddressBusinessRules
    {
        /// <summary>
        /// This rule ensures that user's address name for delivery address is set.
        /// </summary>
        public static readonly BusinessRule AddressNameRequired = 
            new BusinessRule("AddressName", BusinessRules.DeliveryAddress_AddressNameRequired);

        /// <summary>
        /// This rule ensures that user's address name for delivery address is set.
        /// </summary>
        public static readonly BusinessRule FirstNameRequired =
            new BusinessRule("FirstName", BusinessRules.DeliveryAddress_FirstNameRequired);

        /// <summary>
        /// This rule ensures that user's address name for delivery address is set.
        /// </summary>
        public static readonly BusinessRule LastNameRequired =
            new BusinessRule("LastName", BusinessRules.DeliveryAddress_LastNameRequired);
    }
}
