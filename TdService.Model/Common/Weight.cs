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
    using System;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The weight of an order.
    /// </summary>
    public class Weight : EntityBase<int>
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

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not yet implemented.
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}