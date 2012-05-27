// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Currency.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This class describes the currency.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Balance
{
    using System;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// This class describes the currency.
    /// </summary>
    public class Currency : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets Entity (country).
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// Gets or sets Alphabetic Code.
        /// </summary>
        public string AlphabeticCode { get; set; }

        /// <summary>
        /// Gets or sets Numeric Code.
        /// </summary>
        public string NumericCode { get; set; }

        /// <summary>
        /// Gets or sets Minor Unit.
        /// </summary>
        public int MinorUnit { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not yet implemented
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}