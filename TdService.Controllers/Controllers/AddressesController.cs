// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressesController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The addresses controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Xml;

    using TdService.Infrastructure.Authentication;
    using TdService.Infrastructure.Domain;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The addresses controller.
    /// </summary>
    public class AddressesController : ApiController
    {
        /// <summary>
        /// The address Service.
        /// </summary>
        private readonly IAddressService addressService;

        /// <summary>
        /// The forms authentication.
        /// </summary>
        private readonly IFormsAuthentication formsAuthentication;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressesController"/> class.
        /// </summary>
        /// <param name="addressService">
        /// The address Service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms Authentication.
        /// </param>
        public AddressesController(IAddressService addressService, IFormsAuthentication formsAuthentication)
        {
            this.addressService = addressService;
            this.formsAuthentication = formsAuthentication;
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
        /// Add delivery address.
        /// </summary>
        /// <param name="model">
        /// The view model.
        /// </param>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [System.Web.Mvc.Authorize(Roles = "Shopper")]
        [System.Web.Mvc.HttpPost]
        public ActionResult Add([Bind]DeliveryAddressViewModel model)
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
                request.IdentityToken = this.formsAuthentication.GetAuthenticationToken();
                var response = this.addressService.AddOrUpdateDeliveryAddress(request);
                result = response.ConvertToDeliveryAddressViewModel();
            }
            else
            {
                result.MessageType = MessageType.Error.ToString();
                result.BrokenRules = new List<BusinessRule>();
                foreach (var failure in validationResult.Errors)
                {
                    result.BrokenRules.Add(new BusinessRule(failure.PropertyName, failure.ErrorMessage));
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
    }
}
