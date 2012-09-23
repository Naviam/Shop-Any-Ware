// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrdersController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   This controller contains methods to work with orders.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Xml;

    using FluentValidation;
    using FluentValidation.Internal;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Domain;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Order;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Order;

    /// <summary>
    /// This controller contains methods to work with orders.
    /// </summary>
    public class OrdersController : BaseAuthController
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
        /// The new orders.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Operator")]
        [HttpPost]
        public ActionResult NewOrders()
        {
            var request = new GetAllOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.orderService.GetAllNew(request);
            var result = response.ConvertToOrderViewModelCollection();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The received orders.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ReceivedOrders()
        {
            var request = new GetAllOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.orderService.GetAllReceived(request);
            var result = response.ConvertToOrderViewModelCollection();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The return requested orders.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ReturnRequestedOrders()
        {
            var request = new GetAllOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.orderService.GetAllReturnRequested(request);
            var result = response.ConvertToOrderViewModelCollection();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Get recent orders.
        /// </summary>
        /// <returns>
        /// Get recent orders in JSON formatted result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Recent()
        {
            var request = new GetMyOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
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
        /// The history.
        /// </summary>
        /// <returns>
        /// Get history orders in JSON formatted result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult History()
        {
            var request = new GetMyOrdersRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() };
            var response = this.orderService.GetHistory(request);
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
        /// Order view model in JSON format.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Add([Bind]string retailerUrl)
        {
            var result = new OrderViewModel { Status = "New", RetailerUrl = retailerUrl };
            var validator = new OrderViewModelValidator();
            var validationResult = validator.Validate(result);
            if (validationResult.IsValid)
            {
                var request = new AddOrderRequest
                {
                    RetailerUrl = retailerUrl,
                    CreatedDate = DateTime.UtcNow,
                    IdentityToken = this.FormsAuthentication.GetAuthenticationToken()
                };
                var response = this.orderService.AddOrder(request);
                result = response.ConverToOrderViewModel();
            }
            else
            {
                result.MessageType = MessageType.Warning.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.ErrorMessage));
                }
            }

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
        /// The <see cref="ActionResult"/>.
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
            var result = response.ConvertToOrderViewModel();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper, Operator")]
        [HttpPost]
        public ActionResult Update(OrderViewModel model)
        {
            var result = new OrderViewModel();
            var validator = new OrderViewModelValidator();
            var validationResult = validator.Validate(new ValidationContext<OrderViewModel>(model, new PropertyChain(), new RulesetValidatorSelector("update")));
            if (validationResult.IsValid)
            {
                var request = model.ConvertToUpdateOrderRequest();
                request.IdentityToken = this.FormsAuthentication.GetAuthenticationToken();
                var response = this.orderService.UpdateOrder(request);
                result = response.ConvertToOrderViewModel();
            }
            else
            {
                result.MessageType = MessageType.Warning.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.ErrorMessage));
                }
            }

            if (result.Id == 0)
            {
                result.Id = model.Id;
            }

            if (string.IsNullOrEmpty(result.OrderNumber))
            {
                result.OrderNumber = model.OrderNumber;
            }

            if (string.IsNullOrEmpty(result.TrackingNumber))
            {
                result.TrackingNumber = model.TrackingNumber;
            }

            if (string.IsNullOrEmpty(result.Status))
            {
                result.Status = model.Status;
            }

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The request for return.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RequestForReturn(OrderViewModel model)
        {
            var result = new OrderViewModel();
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }
    }
}