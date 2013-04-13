// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressMapper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Model.Addresses;
    using TdService.Services.Messaging.Address;

    /// <summary>
    /// Delivery address auto mapper.
    /// </summary>
    public static class DeliveryAddressMapper
    {
        /// <summary>
        /// The convert to get delivery addresses response.
        /// </summary>
        /// <param name="addresses">
        /// The addresses.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Services.Messaging.Address.GetDeliveryAddressesResponse].
        /// </returns>
        public static List<GetDeliveryAddressesResponse> ConvertToGetDeliveryAddressesResponse(this List<DeliveryAddress> addresses)
        {
            return Mapper.Map<List<DeliveryAddress>, List<GetDeliveryAddressesResponse>>(addresses);
        }

        /// <summary>
        /// The convert to delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Model.Addresses.DeliveryAddress.
        /// </returns>
        public static DeliveryAddress ConvertToDeliveryAddress(this AddOrUpdateDeliveryAddressRequest request)
        {
            return Mapper.Map<AddOrUpdateDeliveryAddressRequest, DeliveryAddress>(request);
        }

        /// <summary>
        /// The convert to add delivery address response.
        /// </summary>
        /// <param name="deliveryAddress">
        /// The delivery address.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Address.AddOrUpdateDeliveryAddressResponse.
        /// </returns>
        public static AddOrUpdateDeliveryAddressResponse ConvertToAddDeliveryAddressResponse(this DeliveryAddress deliveryAddress)
        {
            return Mapper.Map<DeliveryAddress, AddOrUpdateDeliveryAddressResponse>(deliveryAddress);
        }

        /// <summary>
        /// The convert to get countries response.
        /// </summary>
        /// <param name="countries">
        /// The countries.
        /// </param>
        /// <returns>
        /// The collection of get countries responses.
        /// </returns>
        public static List<GetCountriesResponse> ConvertToGetCountriesResponse(this List<Country> countries)
        {
            return Mapper.Map<List<Country>, List<GetCountriesResponse>>(countries);
        }
    }
}