// -----------------------------------------------------------------------
// <copyright file="Item.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Items
{
    using System.Collections.Generic;
using TdService.Infrastructure.Domain;
using TdService.Model.Common;
using TdService.Model.Orders;
using TdService.Model.Packages;

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
        /// Gets or sets Color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        public Dimensions Dimensions { get; set; }

        /// <summary>
        /// Gets or sets Weight.
        /// </summary>
        public Weight Weight { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        public List<ItemImage> Images { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets package
        /// </summary>
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int? PackageId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Validate item business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                this.AddBrokenRule(ItemBussinessRules.NameRequired);
            }

            if (this.Quantity == 0)
            {
                this.AddBrokenRule(ItemBussinessRules.QuantityRequired);
            }
        }
    }
}