﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TdService.Infrastructure.Email;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Orders;
    using TdService.Resources;
    using TdService.Services.Base;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Order;

    /// <summary>
    /// The order service.
    /// </summary>
    public class OrderService : ServiceBase, IOrderService
    {
        /// <summary>
        /// Order repository.
        /// </summary>
        private readonly IOrderRepository orderRepository;

        /// <summary>
        /// The email service.
        /// </summary>
        private readonly IEmailService emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">
        /// The order repository.
        /// </param>
        /// <param name="emailService">
        /// The email service.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public OrderService(IOrderRepository orderRepository, IEmailService emailService, ILogger logger)
            : base(logger)
        {
            this.orderRepository = orderRepository;
            this.emailService = emailService;
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
            var orders = this.orderRepository.GetAllReturnRequestedOrdersPaged(request.Skip, request.Take);
            return orders.ConvertToGetAllOrdersResponseCollection();
        }

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
            var orders = this.orderRepository.GetAllNewOrdersPaged(request.Skip, request.Take);
            return orders.ConvertToGetAllOrdersResponseCollection();
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
            var orders = this.orderRepository.GetAllReceivedOrdersPaged(request.Skip, request.Take);
            return orders.ConvertToGetAllOrdersResponseCollection();
        }

        /// <summary>
        /// Get recent orders (new or received within 30 days)
        /// </summary>
        /// <param name="request">
        /// The request message.
        /// </param>
        /// <returns>
        /// The response message.
        /// </returns>
        public List<GetMyOrdersResponse> GetRecent(GetMyOrdersRequest request)
        {
            var recentOrders = this.orderRepository.GetMyRecent(request.IdentityToken);
            return recentOrders.ConvertToMyOrdersResponseCollection();
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
            var history = this.orderRepository.GetMyHistory(request.IdentityToken);
            return history.ConvertToMyOrdersResponseCollection();
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
            var retailer = new Retailer(request.RetailerUrl);
            var newOrder = new Order(OrderStatus.New) { CreatedDate = DateTime.UtcNow, Retailer = retailer };
            var response = new AddOrderResponse { BrokenRules = retailer.GetBrokenRules().ToList() };
            response.BrokenRules.AddRange(newOrder.GetBrokenRules().ToList());
            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                return response;
            }

            try
            {
                var orderResult = this.orderRepository.AddOrder(request.IdentityToken, newOrder);
               
                response = orderResult.ConvertToAddOrderResponse();
                response.Message = CommonResources.OrderAddSuccessMessage;
            }
            catch (Exception ex)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = ex.Message;
                this.Logger.Error(CommonResources.OrderAddErrorMessage, ex);
            }

            return response;
        }

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="request">
        /// Remove order request.
        /// </param>
        /// <returns>
        /// Remove order response.
        /// </returns>
        public RemoveOrderResponse RemoveOrder(RemoveOrderRequest request)
        {
            var response = new RemoveOrderResponse();

            try
            {
                var order = this.orderRepository.RemoveOrder(request.IdentityToken, request.Id);
                response = order.ConvertToRemoveOrderResponse();
                response.Message = CommonResources.OrderRemoveSuccessMessage;
            }
            catch (Exception ex)
            {
                response.Id = request.Id;
                response.MessageType = MessageType.Error;
                response.ErrorCode = ex.Message;
                this.Logger.Error(CommonResources.OrderRemoveErrorMessage, ex);
            }

            return response;
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
            OrderStatus orderStatus;
            Enum.TryParse(request.Status, true, out orderStatus);
            var order = new Order(orderStatus)
                {
                    Id = request.Id,
                    CreatedDate = DateTime.UtcNow,
                    OrderNumber = request.OrderNumber,
                    TrackingNumber = request.TrackingNumber
                };
            var response = new UpdateOrderResponse { BrokenRules = order.GetBrokenRules().ToList() };
            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                return response;
            }

            try
            {
                ////var orderToUpdate = this.orderRepository.GetOrderById(order.Id);
                order.Update(order.OrderNumber, order.TrackingNumber);
                var updatedOrder = this.orderRepository.UpdateOrder(order);
                response = updatedOrder.ConvertToUpdateOrderResponse();
                response.Message = CommonResources.OrderUpdateSuccessMessage;
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = e.Message;
                this.Logger.Error(CommonResources.OrderUpdateErrorMessage, e);
            }

            return response;
        }

        /// <summary>
        /// Updates order status to received
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="OrderReceivedResponse"/>.
        /// </returns>
        public OrderReceivedResponse OrderReceived(OrderReceivedRequest request)
        {
            try
            {
                var order = this.orderRepository.GetOrderById(request.OrderId);
                order.SetAsReceived();
                var updatedOrder = this.orderRepository.UpdateOrder(order);
                if (order.User.Activated)
                {
                    if (updatedOrder.ReceivedDate.HasValue)
                    {
                        var body = string.Format(
                            order.User.Profile.GetEmailResourceString("OrderReceivedEmailBody"),
                            updatedOrder.Retailer.Name,
                            updatedOrder.Id,
                            updatedOrder.ReceivedDate.Value.ToShortDateString(),
                            order.User.Profile.GetFullName());
                        this.emailService.SendMail(
                            EmailResources.EmailActivationFrom,
                            order.User.Email,
                            order.User.Profile.GetEmailResourceString("OrderReceivedEmailSubject"),
                            body);
                    }
                }

                var response = updatedOrder.ConvertToOrderReceivedResponse();
                response.Message = CommonResources.OrderStatusChangedToReceived;
                response.MessageType = MessageType.Success;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.Error(CommonResources.OrderReceivedErrorMessage, ex);
                return new OrderReceivedResponse { MessageType = MessageType.Error, ErrorCode = ex.Message };
            }
        }
    }
}