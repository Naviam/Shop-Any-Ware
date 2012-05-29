// -----------------------------------------------------------------------
// <copyright file="DatabaseInitializer.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql
{
    using System.Data.Entity;

    /// <summary>
    /// Initialize database.
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Initialize ShopAnyWare database.
        /// </summary>
        public static void InitializeShopAnyWare()
        {
            Database.SetInitializer(new ShopAnyWareSql.ShowAnyWareInitializer());
        }
    }
}