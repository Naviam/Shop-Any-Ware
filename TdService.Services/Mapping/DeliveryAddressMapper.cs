// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressMapper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Mapping
{
    using AutoMapper;

    using TdService.Model.Addresses;
    using TdService.Services.ViewModels.Account;

    /// <summary>
    /// Delivery address auto mapper.
    /// </summary>
    public static class DeliveryAddressMapper
    {
        /// <summary>
        /// Convert to delivery address.
        /// </summary>
        /// <param name="deliveryAddressView">
        /// The delivery address view.
        /// </param>
        /// <returns>
        /// Delivery address.
        /// </returns>
        public static DeliveryAddress ConvertToDeliveryAddress(this DeliveryAddressView deliveryAddressView)
        {
            return Mapper.Map<DeliveryAddressView, DeliveryAddress>(deliveryAddressView);
        }
    }
}