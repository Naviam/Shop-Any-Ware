// -----------------------------------------------------------------------
// <copyright file="Item.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Items
{
    using System;
    using Infrastructure.Domain;

    /// <summary>
    /// Product is what user is buying from online shops.
    /// </summary>
    public class Item : EntityBase<int>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Size.
        /// </summary>
        public ItemSize Size { get; set; }

        /// <summary>
        /// Gets or sets Color.
        /// </summary>
        public ItemColor Color { get; set; }

        /// <summary>
        /// Gets or sets Weight.
        /// </summary>
        public Weight Weight { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Validates product.
        /// </summary>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}