// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedCurrencies.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Seed currencies.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.StaticDataSeed
{
    using TdService.Model.Balance;

    /// <summary>
    /// Seed currencies.
    /// </summary>
    public static class SeedCurrencies
    {
        /// <summary>
        /// Populate db with currencies.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void Populate(ShopAnyWareSql context)
        {
            context.Currencies.Add(
            new Currency
            {
                AlphabeticCode = "USD",
                Entity = "UNITED STATES",
                Name = "US Dollar",
                NumericCode = "840",
                MinorUnit = 2
            });
            context.Currencies.Add(
            new Currency
            {
                AlphabeticCode = "EUR",
                Entity = "Europa",
                Name = "Euro",
                NumericCode = "978",
                MinorUnit = 2
            });
            context.Currencies.Add(
            new Currency
            {
                AlphabeticCode = "RUB",
                Entity = "RUSSIAN FEDERATION",
                Name = "Russian Ruble",
                NumericCode = "643",
                MinorUnit = 2
            });

            context.SaveChanges();
        }
    }
}