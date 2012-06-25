// -----------------------------------------------------------------------
// <copyright file="RetailerBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Common
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// Retailer business rules.
    /// </summary>
    public class RetailerBusinessRules
    {
        /// <summary>
        /// This rule ensures that name is set.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", BusinessRules.Retailer_NameRequired);

        /// <summary>
        /// This rule ensures that name is within max length.
        /// </summary>
        public static readonly BusinessRule NameLength =
            new BusinessRule("Name", BusinessRules.Retailer_NameLength);

        /// <summary>
        /// This rule ensures that category is set.
        /// </summary>
        public static readonly BusinessRule CategoryRequired =
            new BusinessRule("Category", BusinessRules.Retailer_CategoryRequired);

        /// <summary>
        /// This rule ensures that category is within max length.
        /// </summary>
        public static readonly BusinessRule CategoryLength =
            new BusinessRule("Category", BusinessRules.Retailer_CategoryLength);

        /// <summary>
        /// This rule ensures that url is set.
        /// </summary>
        public static readonly BusinessRule UrlRequired =
            new BusinessRule("Url", BusinessRules.Retailer_UrlRequired);

        /// <summary>
        /// This rule ensures that url is within max length.
        /// </summary>
        public static readonly BusinessRule UrlLength =
            new BusinessRule("Url", BusinessRules.Retailer_UrlLength);

        /// <summary>
        /// This rule ensures that description is within max length.
        /// </summary>
        public static readonly BusinessRule DescriptionLength =
            new BusinessRule("Description", BusinessRules.Retailer_DescriptionLength);
    }
}