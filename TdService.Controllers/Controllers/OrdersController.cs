// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This controller contains methods to work with orders.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Xml;

    using TdService.Infrastructure.Authentication;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Order;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Order;

    /// <summary>
    /// This controller contains methods to work with orders.
    /// </summary>
    public class OrdersController : BaseController
    {
        /// <summary>
        /// Order service.
        /// </summary>
        private readonly IOrderService orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersController"/> class. 
        /// Order controller constructor.
        /// </summary>
        /// <param name="orderService">
        /// The order service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The form authentication.
        /// </param>
        public OrdersController(
            IOrderService orderService, 
            IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Get recent orders.
        /// </summary>
        /// <returns>
        /// Get recent orders json result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Recent()
        {
            var request = new GetRecentOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.orderService.GetRecent(request);
            var result = response.ConvertToOrderViewModelCollection();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Add new order.
        /// </summary>
        /// <param name="retailerUrl">
        /// The retailer Url.
        /// </param>
        /// <returns>
        /// Json result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Add([Bind]string retailerUrl)
        {
            var request = new AddOrderRequest
                {
                    RetailerUrl = retailerUrl,
                    CreatedDate = DateTime.UtcNow,
                    IdentityToken = this.FormsAuthentication.GetAuthenticationToken()
                };
            var response = this.orderService.AddOrder(request);
            var result = response.ConverToOrderViewModel();
            result.Message = DashboardViewResources.OrderCreatedSuccess;
            result.MessageType = MessageType.Success.ToString();

            var jsonNetResult = new JsonNetResult
                {
                    Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                    Data = result
                };
            return jsonNetResult;
        }

        /// <summary>
        /// Remove order in new status.
        /// </summary>
        /// <param name="orderId">
        /// The order ID to remove.
        /// </param>
        /// <returns>
        /// Json result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Remove(int orderId)
        {
            var request = new RemoveOrderRequest
                {
                    IdentityToken = this.FormsAuthentication.GetAuthenticationToken(),
                    Id = orderId
                };
            var response = this.orderService.RemoveOrder(request);
            var result = new OrderViewModel
                {
                    Id = orderId,
                    Message = response.Message ?? DashboardViewResources.OrderRemovedSuccess,
                    MessageType = response.MessageType.ToString()
                };

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }
    }
}