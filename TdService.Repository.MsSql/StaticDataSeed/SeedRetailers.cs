// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedRetailers.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the SeedRetailers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.StaticDataSeed
{
    using TdService.Model.Common;

    /// <summary>
    /// Seed retailers.
    /// </summary>
    public static class SeedRetailers
    {
        /// <summary>
        /// Populate db with retailers.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void Populate(ShopAnyWareSql context)
        {
            context.Retailers.Add(new Retailer
                {
                    Category = "Computers",
                    Name = "Apple, Inc.", 
                    Url = "apple.com",
                    Description = "Apple Computers"
                });
            context.SaveChanges();
        }
    }
}