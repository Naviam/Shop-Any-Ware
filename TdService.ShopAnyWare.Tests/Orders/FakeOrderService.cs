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
        /// Get recent orders (new or received within 30 days)
        /// </summary>
        /// <param name="request">
        /// The request message.
        /// </param>
        /// <returns>
        /// Collection of response messages.
        /// </returns>
        public List<GetRecentOrdersResponse> GetRecent(GetRecentOrdersRequest request)
        {
            var result = new List<GetRecentOrdersResponse>
                {
                    new GetRecentOrdersResponse
                        {
                            Id = 1,
                            CreatedDate = DateTime.UtcNow.AddDays(-30),
                            OrderNumber = "order number test 1",
                            ReceivedDate = DateTime.UtcNow.AddDays(-5),
                            TrackingNumber = "tracking number test 1",
                            Status = "Received",
                            RetailerUrl = "Amazon, Inc."
                        },
                    new GetRecentOrdersResponse
                        {
                            Id = 2,
                            CreatedDate = DateTime.UtcNow.AddDays(-40),
                            OrderNumber = "order number test 2",
                            ReceivedDate = DateTime.UtcNow.AddDays(-25),
                            TrackingNumber = "tracking number test 2",
                            Status = "Received",
                            RetailerUrl = "Amazon, Inc."
                        },
                    new GetRecentOrdersResponse
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
    }
}
