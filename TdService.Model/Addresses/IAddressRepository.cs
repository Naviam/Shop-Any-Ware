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
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// Collection of user's delivery addresses.
        /// </returns>
        IEnumerable<Address> GetDeliveryAddresses(string username);

        /// <summary>
        /// Get user's personal warehouse address.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// ShopAnyWare address for user's purchases delivery in U.S.
        /// </returns>
        Address GetWarehouseAddress(string username);

        void AddDeliveryAddress(string username, Address address);

        void UpdateDeliveryAddress(Address address);

        void RemoveDeliveryAddress(int addressId);

        Address GetDeliveryAddressDetails(int addressId);
    }
}