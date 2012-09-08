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
        public static List<GetDeliveryAddressesResponse> ConvertToGetDeliveryAddressesResponse(this List<DeliveryAddress> addresses)
        {
            return Mapper.Map<List<DeliveryAddress>, List<GetDeliveryAddressesResponse>>(addresses);
        }

        public static DeliveryAddress ConvertToDeliveryAddress(this AddOrUpdateDeliveryAddressRequest request)
        {
            return Mapper.Map<AddOrUpdateDeliveryAddressRequest, DeliveryAddress>(request);
        }

        public static AddOrUpdateDeliveryAddressResponse ConvertToAddDeliveryAddressResponse(this DeliveryAddress deliveryAddress)
        {
            return Mapper.Map<DeliveryAddress, AddOrUpdateDeliveryAddressResponse>(deliveryAddress);
        }
    }
}