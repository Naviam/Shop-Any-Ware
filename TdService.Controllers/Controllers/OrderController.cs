namespace TdService.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Order;

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
        /// Order controller constructor.
        /// </summary>
        /// <param name="orderService"></param>
        /// <param name="formsAuthentication"></param>
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
        [Authorize]
        [HttpPost]
        public ActionResult GetRecent()
        {
            var request = new GetRecentOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.orderService.GetRecent(request).ToList();
            var viewModelCollection = response.ConvertToOrderViewModelCollection();
            return this.Json(viewModelCollection);
        }
    }
}