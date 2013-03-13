using System.Linq;
using TdService.Model.Orders;
using TdService.Model.Packages;
using System.Data.Entity;
using TdService.Model.Items;

namespace TdService.Repository.MsSql.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<Order> OrdersWithItemsAndImages(this ShopAnyWareSql context)
        {
            return context.Orders.Include(o=>o.Items.Select(i=>i.Images));
        }

        public static IQueryable<Package> PackagesWithItemsAndImages(this ShopAnyWareSql context)
        {
            return context.Packages.Include(p => p.Items.Select(i => i.Images));
        }

        public static IQueryable<Item> ItemsWithImages(this ShopAnyWareSql context)
        {
            return context.Items.Include(item=>item.Images);
        }

        public static IQueryable<Order> OrdersWithItems(this ShopAnyWareSql context)
        {
            return context.Orders.Include(o => o.Items);
        }

        public static IQueryable<Package> PackagesWithItems(this ShopAnyWareSql context)
        {
            return context.Packages.Include(p => p.Items);
        }
    }
}
