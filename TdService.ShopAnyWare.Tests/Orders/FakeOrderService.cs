// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeOrderService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the FakeOrderService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Orders
{
    using System;
    using System.Collections.Generic;

    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Order;

    /// <summary>
    /// The fake order service.
    /// </summary>
    public class FakeOrderService : IOrderService
    {
        /// <summary>
        /// The get all new.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<GetAllOrdersResponse> GetAllNew(GetAllOrdersRequest request)
        {
            return null;
        }

        /// <summary>
        /// The get all received.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<GetAllOrdersResponse> GetAllReceived(GetAllOrdersRequest request)
        {
            return null;
        }

        /// <summary>
        /// The get all return requested.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of orders.
        /// </returns>
        public List<GetAllOrdersResponse> GetAllReturnRequested(GetAllOrdersRequest request)
        {
            return null;
        }

        /// <summary>
        /// Get recent orders (new or received within 30 days)
        /// </summary>
        /// <param name="request">
        /// The request message.
        /// </param>
        /// <returns>
        /// Collection of response messages.
        /// </returns>
        public List<GetMyOrdersResponse> GetRecent(GetMyOrdersRequest request)
        {
            var result = new List<GetMyOrdersResponse>
                {
                    new GetMyOrdersResponse
                        {
                            Id = 1,
                            CreatedDate = DateTime.UtcNow.AddDays(-30),
                            OrderNumber = "order number test 1",
                            ReceivedDate = DateTime.UtcNow.AddDays(-5),
                            TrackingNumber = "tracking number test 1",
                            Status = "Received",
                            RetailerUrl = "Amazon, Inc."
                        },
                    new GetMyOrdersResponse
                        {
                            Id = 2,
                            CreatedDate = DateTime.UtcNow.AddDays(-40),
                            OrderNumber = "order number test 2",
                            ReceivedDate = DateTime.UtcNow.AddDays(-25),
                            TrackingNumber = "tracking number test 2",
                            Status = "Received",
                            RetailerUrl = "Amazon, Inc."
                        },
                    new GetMyOrdersResponse
                        {
                            Id = 3,
                            CreatedDate = DateTime.UtcNow.AddDays(-15),
                            OrderNumber = "order number test 3",
                            ReceivedDate = DateTime.MinValue,
                            TrackingNumber = "tracking number test 3",
                            Status = "New",
                            RetailerUrl = "Amazon, Inc."
                        }
                };

            return result;
        }

        /// <summary>
        /// The get history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The collection of response messages.
        /// </returns>
        public List<GetMyOrdersResponse> GetHistory(GetMyOrdersRequest request)
        {
            return null;
        }

        /// <summary>
        /// Add new order.
        /// </summary>
        /// <param name="request">
        /// The add new order request.
        /// </param>
        /// <returns>
        /// The add order response.
        /// </returns>
        public AddOrderResponse AddOrder(AddOrderRequest request)
        {
            return new AddOrderResponse
                {
                    CreatedDate = request.CreatedDate,
                    RetailerUrl = request.RetailerUrl,
                    Status = "New",
                    Id = 1
                };
        }

        /// <summary>
        /// Remove order in new status.
        /// </summary>
        /// <param name="request">
        /// The remove order request.
        /// </param>
        /// <returns>
        /// The remove order response.
        /// </returns>
        public RemoveOrderResponse RemoveOrder(RemoveOrderRequest request)
        {
            return new RemoveOrderResponse { MessageType = MessageType.Success };
        }

        /// <summary>
        /// The update order.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Order.UpdateOrderResponse.
        /// </returns>
        public UpdateOrderResponse UpdateOrder(UpdateOrderRequest request)
        {
            return null;
        }
    }
}
