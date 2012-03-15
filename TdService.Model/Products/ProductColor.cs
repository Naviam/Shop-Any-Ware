// -----------------------------------------------------------------------
// <copyright file="ProductWeight.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Products
{
    using System;
    using Infrastructure.Domain;

    /// <summary>
    /// Weight attribute of the product.
    /// </summary>
    public class ProductColor : EntityBase<int>, IProductAttribute
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Validates weight attribute.
        /// </summary>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}