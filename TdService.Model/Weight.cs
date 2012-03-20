// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weight.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Weight type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model
{
    /// <summary>
    /// The weight of an order.
    /// </summary>
    public struct Weight
    {
        /// <summary>
        /// Gets or sets Pounds.
        /// </summary>
        public float Pounds { get; set; }

        /// <summary>
        /// Gets or sets Ounces.
        /// </summary>
        public float Ounces { get; set; }

        /// <summary>
        /// Gets or sets Kilograms.
        /// </summary>
        public float Kilograms { get; set; }

        /// <summary>
        /// Gets or sets Grams.
        /// </summary>
        public float Grams { get; set; }
    }
}