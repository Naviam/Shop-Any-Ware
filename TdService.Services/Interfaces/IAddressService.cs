// -----------------------------------------------------------------------
// <copyright file="IAddressService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Address;

    /// <summary>
    /// Interface for address service.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Get user's delivery addresses.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Collection of user's delivery addresses.
        /// </returns>
        List<GetDeliveryAddressesResponse> GetDeliveryAddresses(GetDeliveryAddressesRequest request);

        /// <summary>
        /// Add or update delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Service response.
        /// </returns>
        AddOrUpdateDeliveryAddressResponse AddOrUpdateDeliveryAddress(AddOrUpdateDeliveryAddressRequest request);

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The response.
        /// </returns>
        RemoveDeliveryRequestResponse RemoveAddress(RemoveDeliveryAddressRequest request);

        /// <summary>
        /// The get countries.
        /// </summary>
        /// <returns>
        /// The collection of get countries responses.
        /// </returns>
        List<GetCountriesResponse> GetCountries();
    }
}