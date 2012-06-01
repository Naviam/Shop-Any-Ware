// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using TdService.Model.Addresses;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Address;

    /// <summary>
    /// This class contains service methods to work with delivery addresses.
    /// </summary>
    public class DeliveryAddressService : IAddressService
    {
        /// <summary>
        /// Address repository.
        /// </summary>
        private readonly IAddressRepository addressRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryAddressService"/> class.
        /// </summary>
        /// <param name="addressRepository">
        /// The address repository.
        /// </param>
        public DeliveryAddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        /// <summary>
        /// Get user's delivery addresses collection.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Delivery addresses.
        /// </returns>
        public GetDeliveryAddressesResponse GetDeliveryAddresses(GetDeliveryAddressesRequest request)
        {
            this.addressRepository.GetDeliveryAddresses(request.Email);
            return null;
        }
    }
}