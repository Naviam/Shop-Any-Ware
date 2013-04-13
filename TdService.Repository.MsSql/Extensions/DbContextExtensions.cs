// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbContextExtensions.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The DB context extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Extensions
{
    using System.Data.Entity;
    using System.Linq;

    using TdService.Model.Items;
    using TdService.Model.Orders;
    using TdService.Model.Packages;

    /// <summary>
    /// The DB context extensions.
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// The orders with items and images.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<Order> OrdersWithItemsAndImages(this ShopAnyWareSql context)
        {
            return context.Orders.Include(o => o.Items.Select(i => i.Images));
        }

        /// <summary>
        /// The packages with items and images.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<Package> PackagesWithItemsAndImages(this ShopAnyWareSql context)
        {
            return context.Packages.Include(p => p.Items.Select(i => i.Images));
        }

        /// <summary>
        /// The items with images.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<Item> ItemsWithImages(this ShopAnyWareSql context)
        {
            return context.Items.Include(item => item.Images);
        }

        /// <summary>
        /// The orders with items.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<Order> OrdersWithItems(this ShopAnyWareSql context)
        {
            return context.Orders.Include(o => o.Items);
        }

        /// <summary>
        /// The packages with items.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<Package> PackagesWithItems(this ShopAnyWareSql context)
        {
            return context.Packages.Include(p => p.Items);
        }

        /// <summary>
        /// The packages with user and wallet.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<Package> PackagesWithUserAndWallet(this ShopAnyWareSql context)
        {
            return context.Packages.Include(p => p.User.Wallet).Include(p => p.User.Profile);
        }
    }
}
