// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRetailersService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The RetailersService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using System.Collections.Generic;

    using TdService.Services.Messaging.Retailer;

    /// <summary>
    /// The RetailersService interface.
    /// </summary>
    public interface IRetailersService
    {
        /// <summary>
        /// Get all retailers.
        /// </summary>
        /// <param name="request">
        /// The get all retailers request message.
        /// </param>
        /// <returns>
        /// The collection of get all retailers response messages.
        /// </returns>
        List<GetRetailersResponse> GetAll(GetRetailersRequest request);
    }
}