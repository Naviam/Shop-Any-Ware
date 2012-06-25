// -----------------------------------------------------------------------
// <copyright file="RoleBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// Role business rules.
    /// </summary>
    public class RoleBusinessRules
    {
        /// <summary>
        /// This rule ensures that name is set.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", BusinessRules.Role_NameRequired);

        /// <summary>
        /// This rule ensures that name is within max length.
        /// </summary>
        public static readonly BusinessRule NameLength =
            new BusinessRule("Name", BusinessRules.Role_NameLength);

        /// <summary>
        /// This rule ensures that description is within max length.
        /// </summary>
        public static readonly BusinessRule DescriptionLength =
            new BusinessRule("Description", BusinessRules.Role_DescriptionLength);
    }
}