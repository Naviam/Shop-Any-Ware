// -----------------------------------------------------------------------
// <copyright file="DatabaseInitializer.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService
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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShopAnyWareSql>());
        }
    }
}