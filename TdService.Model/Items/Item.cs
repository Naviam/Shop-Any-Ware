// -----------------------------------------------------------------------
// <copyright file="Item.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Items
{
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
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets Color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Weight.
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public decimal Price { get; set; }

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