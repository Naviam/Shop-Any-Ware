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
        IEnumerable<Address> GetDeliveryAddresses(string username);

        Address GetWarehouseAddress(string username);

        void AddDeliveryAddress(string username, Address address);

        void UpdateDeliveryAddress(Address address);

        void RemoveDeliveryAddress(int addressId);

        Address GetDeliveryAddressDetails(int addressId);
    }
}