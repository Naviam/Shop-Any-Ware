// -----------------------------------------------------------------------
// <copyright file="ItemColor.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Items
{
    using System;
    using Infrastructure.Domain;

    /// <summary>
    /// Weight attribute of the product.
    /// </summary>
    public class ItemColor : EntityBase<int>, IItemAttribute
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