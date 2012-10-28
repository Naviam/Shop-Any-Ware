// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopAnyWareTestInitilizer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Shop any ware db initilizer that drops and recreate database for running db tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Specs
{
    using System.Data.Entity;

    using TdService.Repository.MsSql;

    /// <summary>
    /// Shop any ware database initilizer that drops and recreate database for running db tests.
    /// </summary>
    public class ShopAnyWareTestInitilizer : DropCreateDatabaseAlways<ShopAnyWareSql>
    {
        /// <summary>
        /// Populate database with static data.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(ShopAnyWareSql context)
        {
            ////SeedMembership.Populate(context);
            ////SeedCurrencies.Populate(context);

            //////// SeedRetailers.Populate(context, new FileStorage());
            ////context.Retailers.Add(new Retailer("amazon.com"));
            ////context.Retailers.Add(new Retailer("apple.com"));
            ////context.SaveChanges();
            ////SeedOrders.Populate(context);
            ////SeedPackages.Populate(context);

            base.Seed(context);
        }
    }
}