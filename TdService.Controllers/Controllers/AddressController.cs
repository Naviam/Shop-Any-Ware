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
    using System;
    using System.Web.Mvc;
    using System.Xml;

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
        [Authorize(Roles = "Shopper")]
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
        /// Get user's delivery addresses.
        /// </summary>
        /// <returns>
        /// The model with collection of delivery addresses.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Get()
        {
            var request = new GetDeliveryAddressesRequest
            {
                IdentityToken = this.FormsAuthentication.GetAuthenticationToken()
            };
            var response = this.addressService.GetDeliveryAddresses(request);
            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToDeliveryAddressViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Add delivery address.
        /// </summary>
        /// <param name="model">
        /// The view model.
        /// </param>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Add(DeliveryAddressViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            DeliveryAddressViewModel result;
            try
            {
                var request = model.ConvertToAddDeliveryAddressRequest();
                request.IdentityToken = this.FormsAuthentication.GetAuthenticationToken();
                var response = this.addressService.AddOrUpdateDeliveryAddress(request);
                result = response.ConvertToDeliveryAddressViewModel();
                result.Message = AddressViewResources.AddDeliveryAddressSuccessMessage;
            }
            catch (Exception e)
            {
                result = new DeliveryAddressViewModel
                    { Message = e.Message, MessageType = ViewModelMessageType.Error.ToString() };
            }

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Update delivery address.
        /// </summary>
        /// <param name="model">
        /// The view model.
        /// </param>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Update(DeliveryAddressViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            var request = model.ConvertToAddDeliveryAddressRequest();
            request.IdentityToken = this.FormsAuthentication.GetAuthenticationToken();
            var response = this.addressService.AddOrUpdateDeliveryAddress(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToDeliveryAddressViewModel()
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult Remove(int addressId)
        {
            var request = new RemoveDeliveryAddressRequest
                {
                    IdentityToken = this.FormsAuthentication.GetAuthenticationToken(),
                    Id = addressId
                };

            var response = this.addressService.RemoveAddress(request);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = response.ConvertToDeliveryAddressViewModel()
            };
            return jsonNetResult;
        }
    }
}