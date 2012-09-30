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
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Xml;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Domain;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Address;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The controller contains methods to work with the addresses.
    /// </summary>
    public class AddressController : BaseAuthController
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
        /// The copy delivery address view model.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="destination">
        /// The destination.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Account.DeliveryAddressViewModel.
        /// </returns>
        public static DeliveryAddressViewModel CopyDeliveryAddressViewModel(
            DeliveryAddressViewModel source, DeliveryAddressViewModel destination)
        {
            if (destination.Id == 0)
            {
                destination.Id = source.Id;
            }

            if (string.IsNullOrWhiteSpace(destination.AddressName))
            {
                destination.AddressName = source.AddressName;
            }

            if (string.IsNullOrWhiteSpace(destination.FirstName))
            {
                destination.FirstName = source.FirstName;
            }

            if (string.IsNullOrWhiteSpace(destination.LastName))
            {
                destination.LastName = source.LastName;
            }

            if (string.IsNullOrWhiteSpace(destination.AddressLine1))
            {
                destination.AddressLine1 = source.AddressLine1;
            }

            if (string.IsNullOrWhiteSpace(destination.AddressLine2))
            {
                destination.AddressLine2 = source.AddressLine2;
            }

            if (string.IsNullOrWhiteSpace(destination.City))
            {
                destination.City = source.City;
            }

            if (string.IsNullOrWhiteSpace(destination.Country))
            {
                destination.Country = source.Country;
            }

            if (string.IsNullOrWhiteSpace(destination.State))
            {
                destination.State = source.State;
            }

            if (string.IsNullOrWhiteSpace(destination.Region))
            {
                destination.Region = source.Region;
            }

            if (string.IsNullOrWhiteSpace(destination.ZipCode))
            {
                destination.ZipCode = source.ZipCode;
            }

            if (string.IsNullOrWhiteSpace(destination.Phone))
            {
                destination.Phone = source.Phone;
            }

            return destination;
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
            return this.View("Index");
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

            var result = new DeliveryAddressViewModel();
            var validator = new DeliveryAddressViewModelValidator();
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {
                var request = model.ConvertToAddDeliveryAddressRequest();
                request.IdentityToken = this.FormsAuthentication.GetAuthenticationToken();
                var response = this.addressService.AddOrUpdateDeliveryAddress(request);
                result = response.ConvertToDeliveryAddressViewModel();
            }
            else
            {
                result.MessageType = MessageType.Error.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.CustomState.ToString()));
                }
            }

            result = CopyDeliveryAddressViewModel(model, result);

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

            var result = new DeliveryAddressViewModel();
            var validator = new DeliveryAddressViewModelValidator();
            var validationResult = validator.Validate(model);
            if (validationResult.IsValid)
            {
                var request = model.ConvertToAddDeliveryAddressRequest();
                request.IdentityToken = this.FormsAuthentication.GetAuthenticationToken();
                var response = this.addressService.AddOrUpdateDeliveryAddress(request);
                result = response.ConvertToDeliveryAddressViewModel();
            }
            else
            {
                result.MessageType = MessageType.Error.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.CustomState.ToString()));
                }
            }

            result = CopyDeliveryAddressViewModel(model, result);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <param name="addressId">
        /// The address Id.
        /// </param>
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