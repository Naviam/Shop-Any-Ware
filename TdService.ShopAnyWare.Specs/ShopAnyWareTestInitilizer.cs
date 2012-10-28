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
    /// Shop any ware database initialization that drops and recreate database for running DB tests.
    /// </summary>
    public class ShopAnyWareTestInitilizer : DropCreateDatabaseAlways<ShopAnyWareSql>
    {
    }
}