// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Addresses;
    using TdService.Resources;
    using TdService.Services.Base;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Address;

    /// <summary>
    /// This class contains service methods to work with delivery addresses.
    /// </summary>
    public class DeliveryAddressService : ServiceBase, IAddressService
    {
        /// <summary>
        /// Address repository.
        /// </summary>
        private readonly IAddressRepository addressRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryAddressService"/> class.
        /// </summary>
        /// <param name="addressRepository">
        /// The address repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public DeliveryAddressService(IAddressRepository addressRepository, ILogger logger)
            : base(logger)
        {
            this.addressRepository = addressRepository;
        }

        /// <summary>
        /// Get user's delivery addresses collection.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Delivery addresses.
        /// </returns>
        public List<GetDeliveryAddressesResponse> GetDeliveryAddresses(GetDeliveryAddressesRequest request)
        {
            var deliveryAddresses = this.addressRepository.GetDeliveryAddresses(request.IdentityToken);
            return deliveryAddresses.ConvertToGetDeliveryAddressesResponse();
        }

        /// <summary>
        /// Add or update delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Add or update delivery address response.
        /// </returns>
        public AddOrUpdateDeliveryAddressResponse AddOrUpdateDeliveryAddress(AddOrUpdateDeliveryAddressRequest request)
        {
            var deliveryAddress = request.ConvertToDeliveryAddress();

            var response = new AddOrUpdateDeliveryAddressResponse { BrokenRules = deliveryAddress.GetBrokenRules().ToList() };
            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                response.Message = CommonResources.DeliveryAddressAddOrUpdateErrorMessage;
                return response;
            }

            try
            {
                var address = this.addressRepository.AddOrUpdateDeliveryAddress(request.IdentityToken, deliveryAddress);
                response = address.ConvertToAddDeliveryAddressResponse();
                response.Message = CommonResources.DeliveryAddressAddOrUpdateSuccessMessage;
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.Message = CommonResources.DeliveryAddressAddOrUpdateErrorMessage;
                this.Logger.Error(CommonResources.DeliveryAddressAddOrUpdateErrorMessage, e);
            }

            return response;
        }

        /// <summary>
        /// The remove address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Address.RemoveDeliveryRequestResponse.
        /// </returns>
        public RemoveDeliveryRequestResponse RemoveAddress(RemoveDeliveryAddressRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var response = new RemoveDeliveryRequestResponse();

            try
            {
                var removedAddress = this.addressRepository.RemoveDeliveryAddress(request.IdentityToken, new DeliveryAddress { Id = request.Id });
                response.Id = removedAddress.Id;
                response.Message = CommonResources.DeliveryAddressRemoveSuccessMessage;
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.Message = CommonResources.DeliveryAddressRemoveErrorMessage;
                this.Logger.Error(CommonResources.DeliveryAddressRemoveErrorMessage, e);
            }

            return response;
        }

        /// <summary>
        /// The get countries.
        /// </summary>
        /// <returns>
        /// The collection of get countries responses.
        /// </returns>
        public List<GetCountriesResponse> GetCountries()
        {
            var countries = this.addressRepository.GetCountries();
            var response = countries.ConvertToGetCountriesResponse();
            return response;
        }
    }
}