// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShippingRatesResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The shipping rates response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Usps
{
    /// <summary>
    /// The shipping rates response.
    /// </summary>
    public class ShippingRatesResponse
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the express mail postage price.
        /// </summary>
        public decimal? ExpressMailPostagePrice { get; set; }

        /// <summary>
        /// Gets or sets the priority mail postage price.
        /// </summary>
        public decimal? PriorityMailPostagePrice { get; set; }
    }
}
