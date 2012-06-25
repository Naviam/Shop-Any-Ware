// -----------------------------------------------------------------------
// <copyright file="PackageBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Packages
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// Package business rules.
    /// </summary>
    public class PackageBusinessRules
    {
        /// <summary>
        /// This rule ensures that name of package is set.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", BusinessRules.Package_NameRequired);

        /// <summary>
        /// This rule ensures that name of package within max length.
        /// </summary>
        public static readonly BusinessRule NameLength =
            new BusinessRule("Name", BusinessRules.Package_NameLength);
    }
}