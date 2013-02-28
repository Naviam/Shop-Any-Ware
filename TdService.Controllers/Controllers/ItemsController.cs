// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The items controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;
    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Helpers;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Item;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Item;

    /// <summary>
    /// The items controller.
    /// </summary>
    public class ItemsController : BaseAuthController
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
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Shopper, Operator")]
        public ActionResult AddItemToOrder(OrderItemViewModel itemViewModel)
        {
            var request = itemViewModel.ConvertToAddItemToOrderRequest();
            var response = this.itemsService.AddItemToOrder(request);
            var data = response.ConvertToOrderItemViewModel();
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = data
            };
            return jsonNetResult;
        }

        [HttpPost]
        [Authorize(Roles = "Shopper, Operator")]
        public ActionResult EditOrderItem(OrderItemViewModel itemViewModel)
        {
            var request = itemViewModel.ConvertToEditOrderItemRequest();
            var response = this.itemsService.EditOrderItem(request);
            var data = response.ConvertToOrderItemViewModel();
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = data
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
        /// The <see cref="ActionResult"/>.
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

        /// <summary>
        /// Get package items.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Shopper, Operator")]
        public ActionResult GetPackageItems(int packageId)
        {
            var request = new GetPackageItemsRequest { PackageId = packageId };
            var response = this.itemsService.GetPackageItems(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageItemViewModelCollection()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The remove item.
        /// </summary>
        /// <param name="itemViewModel">
        /// The item view model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Shopper, Operator")]
        public ActionResult RemoveItem(int itemId)
        {
            var request = new RemoveItemRequest { Id = itemId };
            var response = this.itemsService.RemoveItem(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToOrderItemViewModel()
            };
            return jsonNetResult;
        }

        [HttpPost]
        [Authorize(Roles = "Operator")]
        public ActionResult AddItemImage(int itemId)
        {
            HttpPostedFileBase FileData = Request.Files[0];
            int succeded=0, failed=0;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                try
                {
                    AmazonS3Helper.SaveFile(
                        AppConfigHelper.AWSAccessKey,
                        AppConfigHelper.AWSSecretKey,
                        AppConfigHelper.AmazonS3Bucket,
                        Request.Files[i].FileName.Replace('\\', '/'),
                        Request.Files[i].InputStream);
                    var resp = this.itemsService.AddItemImage(
                        new AddItemImageRequest
                            {
                                ItemId = itemId,
                                ImageName = Request.Files[i].FileName,
                                ImageUrl = string.Concat(AppConfigHelper.AWSUrl, AppConfigHelper.AmazonS3Bucket, "/", Request.Files[i].FileName)
                            });
                    succeded++;
                }
                catch(Exception ex)
                {
                    failed++;
                }
            }
            return new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new {Succeded = succeded, Failed = failed}
            };
        }
    }
}