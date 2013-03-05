﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOrderItemsResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get order items response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The get order items response.
    /// </summary>
    public class GetOrderItemsResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Weight Pounds.
        /// </summary>
        public int WeightPounds { get; set; }

        /// <summary>
        /// Gets or sets the weight ounces.
        /// </summary>
        public decimal WeightOunces { get; set; }

        /// <summary>
        /// Gets or sets the dimensions length.
        /// </summary>
        public decimal DimensionsLength { get; set; }

        /// <summary>
        /// Gets or sets the dimensions height.
        /// </summary>
        public decimal DimensionsHeight { get; set; }

        /// <summary>
        /// Gets or sets the dimensions width.
        /// </summary>
        public decimal DimensionsWidth { get; set; }

        /// <summary>
        /// Gets or sets the dimensions girth.
        /// </summary>
        public decimal DimensionsGirth { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }
    }
}