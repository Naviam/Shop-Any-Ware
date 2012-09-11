// -----------------------------------------------------------------------
// <copyright file="RoleBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// Role business rules.
    /// </summary>
    public class RoleBusinessRules
    {
        /// <summary>
        /// This rule ensures that name is set.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", ErrorCode.RoleNameRequired.ToString());

        /// <summary>
        /// This rule ensures that name is within max length.
        /// </summary>
        public static readonly BusinessRule NameLength =
            new BusinessRule("Name", ErrorCode.RoleNameMaxLength.ToString());

        /// <summary>
        /// This rule ensures that description is within max length.
        /// </summary>
        public static readonly BusinessRule DescriptionLength =
            new BusinessRule("Description", ErrorCode.RoleDescriptionMaxLength.ToString());
    }
}