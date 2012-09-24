// -----------------------------------------------------------------------
// <copyright file="RetailerBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Common
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// Retailer business rules.
    /// </summary>
    public class RetailerBusinessRules
    {
        /// <summary>
        /// This rule ensures that name is set.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", ErrorCode.RetailerNameRequired.ToString());

        /// <summary>
        /// This rule ensures that name is within max length.
        /// </summary>
        public static readonly BusinessRule NameLength =
            new BusinessRule("Name", ErrorCode.RetailerNameMaxLength.ToString());

        /// <summary>
        /// This rule ensures that category is within max length.
        /// </summary>
        public static readonly BusinessRule CategoryLength =
            new BusinessRule("Category", ErrorCode.RetailerCategoryMaxLength.ToString());

        /// <summary>
        /// This rule ensures that url is set.
        /// </summary>
        public static readonly BusinessRule UrlRequired =
            new BusinessRule("Url", ErrorCode.RetailerUrlRequired.ToString());

        /// <summary>
        /// This rule ensures that url is within max length.
        /// </summary>
        public static readonly BusinessRule UrlLength =
            new BusinessRule("Url", ErrorCode.RetailerUrlRequired.ToString());

        /// <summary>
        /// This rule ensures that description is within max length.
        /// </summary>
        public static readonly BusinessRule DescriptionLength =
            new BusinessRule("Description", ErrorCode.RetailerDescriptionMaxLength.ToString());
    }
}