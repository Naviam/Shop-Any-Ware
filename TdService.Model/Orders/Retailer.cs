// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Retailer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Shop type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The class describes online retailer shop.
    /// </summary>
    public class Retailer : EntityBase<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Retailer"/> class.
        /// </summary>
        /// <param name="urlOrName">
        /// The url or name.
        /// </param>
        public Retailer(string urlOrName)
        {
            this.Name = urlOrName;
            this.Url = urlOrName;
            this.Category = urlOrName;
            this.Description = urlOrName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Retailer"/> class.
        /// </summary>
        public Retailer()
        {
        }

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

            if (!string.IsNullOrEmpty(this.Category) && this.Category.Length > 64)
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