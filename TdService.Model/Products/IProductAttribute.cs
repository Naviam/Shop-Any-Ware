// -----------------------------------------------------------------------
// <copyright file="IProductAttribute.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Products
{
    /// <summary>
    /// Interface for product attributes.
    /// </summary>
    public interface IProductAttribute
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        string Name { get; set; }
    }
}