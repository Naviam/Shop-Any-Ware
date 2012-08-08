// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExcelHelper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The excel helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Helpers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// The excel helper.
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// Load the collection of retailers from excel file.
        /// </summary>
        /// <param name="path">
        /// The path to excel file with retailers.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Infrastructure.Helpers.ExcelHelper+RetailersSource].
        /// </returns>
        public static List<RetailersSource> LoadRetailersFromExcelFile(string path)
        {
            var excel = new LinqToExcel.ExcelQueryFactory(path);
            var sheet = excel.Worksheet();

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            return sheet.Select(row => new RetailersSource
            {
                Url = row[1],
                Description = row[2]
            }).ToList();
        }
    }
}