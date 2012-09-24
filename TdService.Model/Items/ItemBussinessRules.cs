// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemBussinessRules.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The item bussiness rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Items
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// The item bussiness rules.
    /// </summary>
    public static class ItemBussinessRules
    {
        /// <summary>
        /// The item name required.
        /// </summary>
        public static readonly BusinessRule NameRequired =
            new BusinessRule("Name", ErrorCode.ItemNameRequired.ToString());

        /// <summary>
        /// The item quantity required.
        /// </summary>
        public static readonly BusinessRule QuantityRequired =
            new BusinessRule("Quantity", ErrorCode.ItemQuantityRequired.ToString());

        /// <summary>
        /// The item price required.
        /// </summary>
        public static readonly BusinessRule PriceRequired =
            new BusinessRule("Price", ErrorCode.ItemPriceRequired.ToString());

        /// <summary>
        /// The item weight required.
        /// </summary>
        public static readonly BusinessRule WeightRequired =
            new BusinessRule("Weight", ErrorCode.ItemWeightRequired.ToString());
    }
}