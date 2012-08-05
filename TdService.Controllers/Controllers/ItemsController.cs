﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The items controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Item;
    using TdService.Services.ViewModels.Item;

    using Formatting = System.Xml.Formatting;

    /// <summary>
    /// The items controller.
    /// </summary>
    public class ItemsController : BaseController
    {
        /// <summary>
        /// The items service.
        /// </summary>
        private readonly IItemsService itemsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsController"/> class.
        /// </summary>
        /// <param name="itemsService">
        /// The items Service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public ItemsController(
            IItemsService itemsService,
            IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.itemsService = itemsService;
        }

        /// <summary>
        /// Add item to order.
        /// </summary>
        /// <param name="itemViewModel">
        /// The order item view model.
        /// </param>
        /// <returns>
        /// The json result.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Operator")]
        public ActionResult AddItemToOrder(OrderItemViewModel itemViewModel)
        {
            var request = itemViewModel.ConvertToAddItemToOrderRequest();
            var response = this.itemsService.AddItemToOrder(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToOrderItemViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Get collection of order items.
        /// </summary>
        /// <param name="orderId">
        /// The order ID.
        /// </param>
        /// <returns>
        /// The json result.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Shopper, Operator")]
        public ActionResult GetOrderItems(int orderId)
        {
            var request = new GetOrderItemsRequest { OrderId = orderId };
            var response = this.itemsService.GetOrderItems(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToOrderItemViewModelCollection()
            };
            return jsonNetResult;
        }
    }
}