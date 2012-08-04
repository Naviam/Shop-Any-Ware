// --------------------------------------------------------------------------------------------------------------------
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
    using TdService.Services.ViewModels.Item;

    using Formatting = System.Xml.Formatting;

    /// <summary>
    /// The items controller.
    /// </summary>
    public class ItemsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public ItemsController(
            IItemsService 
            IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
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
            var request = itemViewModel.ConvertToRequest();
            var response = itemViewModel;
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response
            };
            return jsonNetResult;
        }
    }
}