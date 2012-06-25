// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Retailer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Shop type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Common
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The class describes online retailer shop.
    /// </summary>
    public class Retailer : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Validate against rules method.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.AddBrokenRule(RetailerBusinessRules.NameRequired);
            }
            else if (this.Name.Length > 64)
            {
                this.AddBrokenRule(RetailerBusinessRules.NameLength);
            }

            if (string.IsNullOrEmpty(this.Category))
            {
                this.AddBrokenRule(RetailerBusinessRules.CategoryRequired);
            }
            else if (this.Category.Length > 64)
            {
                this.AddBrokenRule(RetailerBusinessRules.CategoryLength);
            }

            if (string.IsNullOrEmpty(this.Url))
            {
                this.AddBrokenRule(RetailerBusinessRules.UrlRequired);
            }
            else if (this.Url.Length > 256)
            {
                this.AddBrokenRule(RetailerBusinessRules.UrlLength);
            }

            if (string.IsNullOrEmpty(this.Description))
            {
                this.AddBrokenRule(RetailerBusinessRules.DescriptionLength);
            }
        }
    }
}