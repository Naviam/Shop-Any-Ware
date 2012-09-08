// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the AddressController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Address;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The controller contains methods to work with the addresses.
    /// </summary>
    public class AddressController : BaseController
    {
        /// <summary>
        /// The address Service.
        /// </summary>
        private readonly IAddressService addressService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        /// <param name="addressService">
        /// The address Service.
        /// </param>
        public AddressController(IFormsAuthentication formsAuthentication, IAddressService addressService)
            : base(formsAuthentication)
        {
            this.addressService = addressService;
        }

        /// <summary>
        /// Show the list of delivery addresses.
        /// </summary>
        /// <returns>
        /// Returns view with the delivery addresses.
        /// </returns>
        public ActionResult Index()
        {
            var request = new GetDeliveryAddressesRequest
                {
                    IdentityToken = this.FormsAuthentication.GetAuthenticationToken()
                };
            var response = this.addressService.GetDeliveryAddresses(request);
            return this.View("Index", response.ConvertToDeliveryAddressViewModel());
        }

        /// <summary>
        /// Add delivery address.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [HttpPost]
        public JsonResult Add(DeliveryAddressViewModel view)
        {
            try
            {
                var request = view.ConvertToAddDeliveryAddressRequest();
                var response = this.addressService.AddDeliveryAddress(request);
                view.Message = AddressViewResources.AddDeliveryAddressSuccessMessage;
                view.MessageType = ViewModelMessageType.Success.ToString().ToLower();
            }
            catch (System.Exception e)
            {
                view.Message = e.Message;
                view.MessageType = ViewModelMessageType.Error.ToString().ToLower();
            }

            return this.Json(view);
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [HttpPost]
        public JsonResult Remove()
        {
            return this.Json(string.Empty);
        }

        /// <summary>
        /// Update delivery address.
        /// </summary>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [HttpPost]
        public JsonResult Update()
        {
            return this.Json(string.Empty);
        }
    }
}