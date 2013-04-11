// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeAddressService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The fake address service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Addresses
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Model.Addresses;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Address;

    /// <summary>
    /// The fake address service.
    /// </summary>
    public class FakeAddressService : IAddressService
    {
        /// <summary>
        /// The addresses.
        /// </summary>
        private readonly List<DeliveryAddress> addresses = new List<DeliveryAddress>
                {
                    new DeliveryAddress
                        {
                            Id = 1,
                            AddressLine1 = "Novovilenskaya 10, 41",
                            AddressLine2 = string.Empty,
                            AddressName = "My first address",
                            City = "Москва",
                            Country = new Country{Code="RU",Id=183},
                            Region = null,
                            State = null,
                            ZipCode = "11003",
                            FirstName = "Vitali",
                            LastName = "Hatalski",
                            Phone = "+575929933"
                        },
                    new DeliveryAddress
                        {
                            Id = 2,
                            AddressLine1 = "Nekrasove 8, 14",
                            AddressLine2 = string.Empty,
                            AddressName = "My second address",
                            City = "Минск",
                            Country = new Country{Code="BY",Id=21},
                            Region = null,
                            State = null,
                            ZipCode = "29482",
                            FirstName = "Vitali",
                            LastName = "Hatalski",
                            Phone = "+575929933"
                        }
                };

        /// <summary>
        /// Get user's delivery addresses.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Collection of user's delivery addresses.
        /// </returns>
        public List<GetDeliveryAddressesResponse> GetDeliveryAddresses(GetDeliveryAddressesRequest request)
        {
            return this.addresses.ConvertToGetDeliveryAddressesResponse();
        }

        /// <summary>
        /// Add or update delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Service response.
        /// </returns>
        public AddOrUpdateDeliveryAddressResponse AddOrUpdateDeliveryAddress(AddOrUpdateDeliveryAddressRequest request)
        {
            var newAddress = request.ConvertToDeliveryAddress();
            var address = this.addresses.Find(a => a.Id == request.Id);
            if (address == null)
            {
                newAddress.Id = this.addresses.Count;
                this.addresses.Add(newAddress);
                return newAddress.ConvertToAddDeliveryAddressResponse();
            }

            var id = address.Id;
            address = newAddress;
            address.Id = id;
            return address.ConvertToAddDeliveryAddressResponse();
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The response.
        /// </returns>
        public RemoveDeliveryRequestResponse RemoveAddress(RemoveDeliveryAddressRequest request)
        {
            var result = this.addresses.RemoveAll(a => a.Id == request.Id);
            return new RemoveDeliveryRequestResponse { Id = result == 1 ? request.Id : 0 };
        }


        List<GetCountriesResponse> IAddressService.GetCountries()
        {
            throw new System.NotImplementedException();
        }
    }
}
