// -----------------------------------------------------------------------
// <copyright file="CourierBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Shipping
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// Courier business rules.
    /// </summary>
    public class CourierBusinessRules
    {
        /// <summary>
        /// This rule ensures that name for courier is set.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", ErrorCode.CourierNameRequired.ToString());

        /// <summary>
        /// This rule ensures that name for courier within max length.
        /// </summary>
        public static readonly BusinessRule NameMaxLength =
            new BusinessRule("Name", ErrorCode.CourierNameMaxLength.ToString());
    }
}