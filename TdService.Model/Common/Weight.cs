// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weight.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Weight type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Common
{
    /// <summary>
    /// The weight of an order.
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// Gets or sets Pounds.
        /// </summary>
        public decimal Pounds { get; set; }

        /// <summary>
        /// Gets or sets Ounces.
        /// </summary>
        [System.Obsolete]
        public decimal Ounces { get; set; }
    }
}