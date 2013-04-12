// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedCountries.cs" company="Naviam">
//   Vitali Hatalski. 2013.
// </copyright>
// <summary>
//   Defines the SeedCountries type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.StaticDataSeed
{
    using System.Linq;
    using System.Xml.Linq;

    using TdService.Infrastructure.FileSystem;
    using TdService.Model.Addresses;

    /// <summary>
    /// The seed countries.
    /// </summary>
    public static class SeedCountries
    {
        /// <summary>
        /// The populate.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="fileStorage">
        /// The file Storage.
        /// </param>
        public static void Populate(ShopAnyWareSql context, IFileStorage fileStorage)
        {
            var path = fileStorage.MapPath("~/App_Data/countries.xml");
            var doc = XElement.Load(path);
            var countries =
                from el in doc.Elements()
                let xElement = el.Element("ISO_3166-1_Country_name")
                where xElement != null
                let element = el.Element("ISO_3166-1_Alpha-2_Code_element")
                where element != null
                select new Country
                           {
                               DefaultName = xElement.Value.Trim(),
                               Code = element.Value.Trim()
                           };
            countries.ToList().ForEach(c => context.Countries.Add(c));
            context.SaveChanges();
        }
    }
}
