// -----------------------------------------------------------------------
// <copyright file="CourierBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Shipping
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// Courier business rules.
    /// </summary>
    public class CourierBusinessRules
    {
        /// <summary>
        /// This rule ensures that name for courier is set.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", BusinessRules.Courier_NameRequired);

        /// <summary>
        /// This rule ensures that name for courier within max length.
        /// </summary>
        public static readonly BusinessRule NameMaxLength = 
            new BusinessRule("Name", BusinessRules.Courier_NameMaxLength);
    }
}