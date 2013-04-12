// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddressRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IAddressRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for address repository.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Get the list of user's delivery addresses.
        /// </summary>
        /// <param name="email">
        /// The username.
        /// </param>
        /// <returns>
        /// Collection of user's delivery addresses.
        /// </returns>
        List<DeliveryAddress> GetDeliveryAddresses(string email);

        /// <summary>
        /// Get user's personal warehouse address.
        /// </summary>
        /// <param name="email">
        /// The username.
        /// </param>
        /// <returns>
        /// ShopAnyWare address for user's purchases delivery in U.S.
        /// </returns>
        WarehouseAddress GetWarehouseAddress(string email);

        /// <summary>
        /// Get user's delivery address details.
        /// </summary>
        /// <param name="addressId">
        /// The address id.
        /// </param>
        /// <returns>
        /// Delivery address object.
        /// </returns>
        DeliveryAddress GetDeliveryAddressDetails(int addressId);

        /// <summary>
        /// Add user's delivery address.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// The TdService.Model.Addresses.DeliveryAddress.
        /// </returns>
        DeliveryAddress AddOrUpdateDeliveryAddress(string email, DeliveryAddress address);

        /// <summary>
        /// Remove user's delivery address.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// The TdService.Model.Addresses.DeliveryAddress.
        /// </returns>
        DeliveryAddress RemoveDeliveryAddress(string email, DeliveryAddress address);

        /// <summary>
        /// Get country list
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountries();
    }
}