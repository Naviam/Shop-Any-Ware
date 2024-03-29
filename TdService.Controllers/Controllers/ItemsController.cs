﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Web.Mvc;
    using System.Xml;
    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Helpers;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Item;
    using TdService.UI.Web.Controllers.Base;
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

        /// <summary>
        /// The edit order item.
        /// </summary>
        /// <param name="itemViewModel">
        /// The item view model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
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
        /// The edit package item.
        /// </summary>
        /// <param name="itemViewModel">
        /// The item view model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Shopper, Operator")]
        public ActionResult EditPackageItem(PackageItemViewModel itemViewModel)
        {
            var request = itemViewModel.ConvertToEditPackageItemRequest();
            var response = this.itemsService.EditPackageItem(request);
            var data = response.ConvertToPackageItemViewModel();
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
        /// <param name="itemId">
        /// The item Id.
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

        /// <summary>
        /// The add item image.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [Authorize(Roles = "Operator")]
        public ActionResult AddItemImage(int itemId)
        {
            var fileName = Guid.NewGuid().ToString();
            
            // todo: handle the situation with no files in request gracefully
            var httpPostedFileBase = this.Request.Files[0];
            if (httpPostedFileBase != null)
            {
                AmazonS3Helper.SaveFile(
                    AppConfigHelper.AwsAccessKey,
                    AppConfigHelper.AwsSecretKey,
                    AppConfigHelper.AmazonS3Bucket,
                    fileName,
                    httpPostedFileBase.InputStream);
            }

            if (httpPostedFileBase != null)
            {
                var resp = this.itemsService.AddItemImage(
                    new AddItemImageRequest
                        {
                            ItemId = itemId,
                            ImageName = httpPostedFileBase.FileName,
                            ImageUrl = string.Concat(AppConfigHelper.AwsUrl, AppConfigHelper.AmazonS3Bucket, "/", fileName)
                        });
                var jsonNetResult = new JsonNetResult
                                        {
                                            ContentType = "text/html",
                                            Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                                            Data = resp.ConvertToItemImageViewModel()
                                        };
                return jsonNetResult;
            }

            return null;
        }

        /// <summary>
        /// The move order items to existing package.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult MoveOrderItemsToExistingPackage(int orderId, int packageId)
        {
            var request = new MoveOrderItemsToExistingPackageRequest { OrderId = orderId, PackageId = packageId };
            var response = this.itemsService.MoveOrderItemsToExistingPackage(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageItemViewModelCollection()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The move order item to new package.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult MoveOrderItemToNewPackage(int itemId, int packageId)
        {
            var request = new MoveOrderItemToExistingPackageRequest { ItemId = itemId, PackageId = packageId };
            var response = this.itemsService.MoveOrderItemsToExistingPackage(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToMoveOrderItemToExistingPackageViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The move order items to original order.
        /// </summary>
        /// <param name="packageId">
        /// The package id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult MoveOrderItemsToOriginalOrder(int packageId)
        {
            var request = new MoveOrderItemsToOriginalOrderRequest { PackageId = packageId };
            var response = this.itemsService.MoveOrderItemsToOriginalOrder(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageItemViewModelCollection()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The move order item to original order.
        /// </summary>
        /// <param name="itemId">
        /// The item id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult MoveOrderItemToOriginalOrder(int itemId)
        {
            var request = new MoveItemBackToOriginalOrderRequest { ItemId = itemId };
            var response = this.itemsService.MoveOrderItemBackToOriginalOrder(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToPackageItemViewModel()
            };
            return jsonNetResult;
        }
    }
}