// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This controller contains methods to work with orders.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Order;
    using TdService.Services.ViewModels.Order;

    /// <summary>
    /// This controller contains methods to work with orders.
    /// </summary>
    public class OrderController : BaseController
    {
        /// <summary>
        /// Order service.
        /// </summary>
        private readonly IOrderService orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class. 
        /// Order controller constructor.
        /// </summary>
        /// <param name="orderService">
        /// The order service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The form authentication.
        /// </param>
        public OrderController(
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
        public ActionResult GetRecent()
        {
            var request = new GetRecentOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.orderService.GetRecent(request);
            var result = response.ConvertToOrderViewModelCollection();
            return this.Json(result);
        }

        /// <summary>
        /// Add new order.
        /// </summary>
        /// <param name="model">
        /// The order view model.
        /// </param>
        /// <returns>
        /// Json result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult AddOrder(OrderViewModel model)
        {
            var request = model.ConvertToAddOrderRequest();
            request.IdentityToken = this.FormsAuthentication.GetAuthenticationToken();
            var response = this.orderService.AddOrder(request);
            var result = response.ConverToOrderViewModel();
            return this.Json(result);
        }
    }
}