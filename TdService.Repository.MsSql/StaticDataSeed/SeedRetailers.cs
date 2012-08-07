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
    using System.IO;
    using System.Web;

    using TdService.Infrastructure.Helpers;
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
            var path = HttpContext.Current.Server.MapPath("~/App_Data/retailers.txt");
            var retailers = ExcelHelper.LoadRetailersFromExcelFile(path);

            foreach (var retailer in retailers)
            {
                context.Retailers.Add(new Retailer
                {
                    Category = retailer.Url,
                    Name = retailer.Url,
                    Url = retailer.Url,
                    Description = retailer.Description
                });
            }

            context.SaveChanges();
        }
    }
}