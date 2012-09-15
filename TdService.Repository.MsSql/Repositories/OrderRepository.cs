// -----------------------------------------------------------------------
// <copyright file="OrderRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Orders;

    /// <summary>
    /// Order repository to work with orders in database.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Get order details.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <returns>
        /// Order details.
        /// </returns>
        public Order GetOrderById(int orderId)
        {
            using (var context = new ShopAnyWareSql())
            {
                return context.Orders.Find(orderId);
            }
        }

        /// <summary>
        /// The get all new orders paged.
        /// </summary>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<Order> GetAllNewOrdersPaged(int skip, int take)
        {
            using (var context = new ShopAnyWareSql())
            {
                var query = context.Orders.Where(o => o.Status == OrderStatus.New)
                    .OrderByDescending(o => o.CreatedDate);
                return query.Skip(skip).Take(take).ToList();
            }
        }

        /// <summary>
        /// The get all received orders paged.
        /// </summary>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<Order> GetAllReceivedOrdersPaged(int skip, int take)
        {
            using (var context = new ShopAnyWareSql())
            {
                var query = context.Orders.Where(o => o.Status == OrderStatus.Received)
                    .OrderByDescending(o => o.CreatedDate);
                return query.Skip(skip).Take(take).ToList();
            }
        }

        /// <summary>
        /// The get all return requested orders paged.
        /// </summary>
        /// <param name="skip">
        /// The skip.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<Order> GetAllReturnRequestedOrdersPaged(int skip, int take)
        {
            using (var context = new ShopAnyWareSql())
            {
                var query = context.Orders.Where(o => o.Status == OrderStatus.ReturnRequested)
                    .OrderByDescending(o => o.CreatedDate);
                return query.Skip(skip).Take(take).ToList();
            }
        }

        /// <summary>
        /// The get my recent.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<Order> GetMyRecent(string email)
        {
            using (var context = new ShopAnyWareSql())
            {
                var query = from o in context.Orders.Include("Retailer")
                            where
                                o.User.Email == email
                                &&
                                (o.Status == OrderStatus.New || o.Status == OrderStatus.Received
                                 || o.Status == OrderStatus.ReturnRequested)
                            orderby o.CreatedDate descending
                            select o;
                return query.ToList();
            }
        }

        /// <summary>
        /// The get my history.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<Order> GetMyHistory(string email)
        {
            using (var context = new ShopAnyWareSql())
            {
                var query = from o in context.Orders.Include("Retailer")
                            where
                                o.User.Email == email
                                &&
                                (o.Status == OrderStatus.Returned || o.Status == OrderStatus.Disposed)
                            orderby o.CreatedDate descending
                            select o;
                return query.ToList();
            }
        }

        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="order">
        /// The order to add.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order AddOrder(string email, Order order)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("Profile").Include("Wallet").Include("Roles").Include("Orders")
                    .SingleOrDefault(u => u.Email == email);
                if (user == null)
                {
                    throw new ArgumentNullException(ErrorCode.UserNotFound.ToString());
                }

                order.Retailer = context.Retailers.SingleOrDefault(r => r.Url == order.Retailer.Url)
                               ?? context.Retailers.Add(order.Retailer);
                context.Orders.Add(order);
                if (user.Orders == null)
                {
                    user.Orders = new List<Order>();
                }

                user.AddOrder(order);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

                return order;
            }
        }

        /// <summary>
        /// Update the order.
        /// </summary>
        /// <param name="order">
        /// The order to update.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order UpdateOrder(Order order)
        {
            using (var context = new ShopAnyWareSql())
            {
                context.Orders.Attach(order);
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
                return order;
            }
        }

        /// <summary>
        /// Remove an order.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="orderId">
        /// The order ID to remove.
        /// </param>
        /// <returns>
        /// The TdService.Model.Orders.Order.
        /// </returns>
        public Order RemoveOrder(string email, int orderId)
        {
            using (var context = new ShopAnyWareSql())
            {
                var user = context.Users.Include("Profile").Include("Wallet").Include("Orders").Include("Roles").SingleOrDefault(u => u.Email == email);
                if (user == null)
                {
                    throw new ArgumentNullException(ErrorCode.UserNotFound.ToString());
                }

                var order = user.RemoveOrder(orderId);
                context.Orders.Attach(order);
                //// TODO : make a cascading delete in the database
                context.Entry(order).Collection(o => o.Items).Load();
                context.Orders.Remove(order);
                context.SaveChanges();
                return order;
            }
        }
    }
}