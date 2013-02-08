// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RetailersService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The retailers service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System.Collections.Generic;
    using TdService.Infrastructure.Logging;
    using TdService.Model.Common;
    using TdService.Model.Orders;
    using TdService.Services.Base;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging.Retailer;

    /// <summary>
    /// The retailers service.
    /// </summary>
    public class RetailersService :ServiceBase, IRetailersService
    {
        /// <summary>
        /// The retailer repository.
        /// </summary>
        private readonly IRetailerRepository retailerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetailersService"/> class.
        /// </summary>
        /// <param name="retailerRepository">
        /// The retailer repository.
        /// </param>
        public RetailersService(IRetailerRepository retailerRepository, ILogger logger):base(logger)
        {
            this.retailerRepository = retailerRepository;
        }

        /// <summary>
        /// Get all retailers.
        /// </summary>
        /// <param name="request">
        /// The get all retailers request message.
        /// </param>
        /// <returns>
        /// The collection of get all retailers response messages.
        /// </returns>
        public List<GetRetailersResponse> GetAll(GetRetailersRequest request)
        {
            var result = this.retailerRepository.GetAll();
            return result.ConvertToGetRetailersResponseCollection();
        }
    }
}