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
    using System.Linq;

    using TdService.Infrastructure.FileSystem;
    using TdService.Infrastructure.Helpers;
    using TdService.Model.Orders;

    /// <summary>
    /// Seed retailers.
    /// </summary>
    public static class SeedRetailers
    {
        /// <summary>
        /// Populate DB with retailers.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="fileStorage">
        /// The file storage.
        /// </param>
        public static void Populate(ShopAnyWareSql context, IFileStorage fileStorage)
        {
            var path = fileStorage.MapPath("~/App_Data/retailers.xls");
            var retailersExcel = ExcelHelper.LoadRetailersFromExcelFile(path);
            var retailers = retailersExcel.Select(r => new Retailer(r.Url)).ToList();
            var retailers2 = retailers.Where(r => string.IsNullOrWhiteSpace(r.Url) == false).ToList();
            retailers2.ForEach(r => context.Retailers.Add(r));
            context.SaveChanges();
        }
    }
}