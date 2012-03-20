// -----------------------------------------------------------------------
// <copyright file="ItemSize.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Items
{
    using System;
    using Infrastructure.Domain;

    /// <summary>
    /// Size attribute of the product.
    /// </summary>
    public class ItemSize : EntityBase<int>, IItemAttribute
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Validates size attribute.
        /// </summary>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}