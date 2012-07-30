// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopAnyWareTestInitilizer.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Shop any ware db initilizer that drops and recreate database for running db tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Repository
{
    using System.Data.Entity;

    using TdService.Repository.MsSql;
    using TdService.Repository.MsSql.StaticDataSeed;

    /// <summary>
    /// Shop any ware db initilizer that drops and recreate database for running db tests.
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
            context.Database.ExecuteSqlCommand("ALTER TABLE Retailers ADD CONSTRAINT rc_Url UNIQUE(Url)");

            SeedMembership.Populate(context);
            SeedCurrencies.Populate(context);
            SeedRetailers.Populate(context);
            SeedOrders.Populate(context);

            base.Seed(context);
        }
    }
}