// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeedOrders.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The seed orders.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.StaticDataSeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TdService.Model.Orders;

    /// <summary>
    /// The seed orders.
    /// </summary>
    public static class SeedOrders
    {
        /// <summary>
        /// Populate database with few orders.
        /// </summary>
        /// <param name="context">
        /// Shop any ware context.
        /// </param>
        public static void Populate(ShopAnyWareSql context)
        {
            var user = context.Users.SingleOrDefault(u => u.Email == "vhatalski@naviam.com");
            var retailer = context.Retailers.Find(1);
            if (user != null)
            {
                user.Orders = new List<Order>
                    {
                        new Order(OrderStatus.New)
                            {
                                Retailer = retailer,
                                CreatedDate = DateTime.UtcNow
                            },
                        new Order(OrderStatus.Received)
                            {
                                Retailer = retailer,
                                CreatedDate = DateTime.UtcNow.AddDays(-5),
                                ReceivedDate = DateTime.UtcNow.AddHours(-3)
                            }
                    };
            }

            context.SaveChanges();
        }
    }
}