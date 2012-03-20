// -----------------------------------------------------------------------
// <copyright file="OrderRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService
{
    using System;
    using System.Collections.Generic;
    using Model.Orders;

    /// <summary>
    /// Order repository to work with orders in database.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        public void AddOrder(Order order, string userId)
        {
            using (var context = new TdServiceContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void RemoveOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders(object sortDirection, string sortExpression, string filterExpression, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetUserOrders(string username, object sortDirection, string sortExpression, string filterExpression, int pageSize = 20)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        public void RequestPhotos(int orderId)
        {
            throw new NotImplementedException();
        }

        public void AddPhotos(int orderId, IEnumerable<Domain.Picture> picture)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public void UpdateArrivalDate(int orderId, DateTime arrivalDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderWeight(int orderId, Model.Weight weight)
        {
            throw new NotImplementedException();
        }
    }
}
