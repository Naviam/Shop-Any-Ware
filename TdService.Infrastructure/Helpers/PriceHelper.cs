// -----------------------------------------------------------------------
// <copyright file="PriceHelper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Helpers
{
    /// <summary>
    /// All product, order, and package prices will be displayed in U.S. dollars and will be formatted in the same manner.
    /// </summary>
    public static class PriceHelper
    {
        /// <summary>
        /// Format money.
        /// </summary>
        /// <param name="price">
        /// The price.
        /// </param>
        /// <returns>
        /// Formatted money.
        /// </returns>
        public static string FormatMoney(this decimal price)
        {
            return string.Format("${0}", price);
        }
    }
}