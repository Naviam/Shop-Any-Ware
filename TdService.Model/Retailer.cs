// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Retailer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Shop type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model
{
    /// <summary>
    /// The class describes online retailer shop.
    /// </summary>
    public class Retailer
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }
    }
}