// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the AddressController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Address;
    using TdService.Services.ViewModels;
    using TdService.Services.ViewModels.Account;

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
                    Email = FormsAuthentication.GetAuthenticationToken()
                };
            var response = this.addressService.GetDeliveryAddresses(request);
            return this.View("Index", response.DeliveryAddressesView);
        }

        /// <summary>
        /// Get own warehouse address in USA.
        /// </summary>
        /// <returns>
        /// Returns view with the warehouse address details.
        /// </returns>
        public ActionResult Warehouse()
        {
            return this.View();
        }

        /// <summary>
        /// Get delivery address details.
        /// </summary>
        /// <param name="addressId">
        /// The address Id.
        /// </param>
        /// <returns>
        /// Returns view with delivery address details.
        /// </returns>
        public ActionResult Details(int addressId)
        {
            return this.View();
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
        public JsonResult Add(DeliveryAddressView view)
        {
            var addressesView = new DeliveryAddressesView();
            try
            {
                var response = this.addressService.AddDeliveryAddress(
                        new AddDeliveryAddressRequest
                            {
                                DeliveryAddressesView = new DeliveryAddressesView { DeliveryAddressView = view }
                            });
                addressesView = response.DeliveryAddressesView;
                addressesView.Message = AddressViewResources.AddDeliveryAddressSuccessMessage;
                addressesView.MessageType = ViewModelMessageType.Error;
            }
            catch (System.Exception e)
            {
                addressesView.Message = e.Message;
                addressesView.MessageType = ViewModelMessageType.Error;
            }
            return this.Json(addressesView);
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