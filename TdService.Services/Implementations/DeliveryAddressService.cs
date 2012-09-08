// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TdService.Model.Addresses;
    using TdService.Model.Membership;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
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
        /// User repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryAddressService"/> class.
        /// </summary>
        /// <param name="addressRepository">
        /// The address repository.
        /// </param>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        public DeliveryAddressService(IAddressRepository addressRepository, IUserRepository userRepository)
        {
            this.addressRepository = addressRepository;
            this.userRepository = userRepository;
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
        public List<GetDeliveryAddressesResponse> GetDeliveryAddresses(GetDeliveryAddressesRequest request)
        {
            var deliveryAddresses = this.addressRepository.GetDeliveryAddresses(request.IdentityToken);
            return deliveryAddresses.ConvertToGetDeliveryAddressesResponse();
        }

        /// <summary>
        /// Add or update delivery address.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Add or update delivery address response.
        /// </returns>
        public AddOrUpdateDeliveryAddressResponse AddOrUpdateDeliveryAddress(AddOrUpdateDeliveryAddressRequest request)
        {
            var deliveryAddress = request.ConvertToDeliveryAddress();

            ThrowExceptionIfDeliveryAddressIsInvalid(deliveryAddress);

            var address = this.addressRepository.AddOrUpdateDeliveryAddress(deliveryAddress);
            this.addressRepository.SaveChanges();

            this.userRepository.AttachAddress(request.IdentityToken, address.Id);
            this.userRepository.SaveChanges();

            return address.ConvertToAddDeliveryAddressResponse();
        }

        public RemoveDeliveryRequestResponse RemoveAddress(RemoveDeliveryAddressRequest request)
        {
            var removedAddress = this.addressRepository.RemoveDeliveryAddress(new DeliveryAddress { Id = request.Id });
            var response = new RemoveDeliveryRequestResponse { Id = removedAddress.Id };
            return response;
        }

        /// <summary>
        /// Validates delivery address.
        /// </summary>
        /// <param name="address">
        /// The profile.
        /// </param>
        /// <exception cref="InvalidDeliveryAddressException">
        /// Thrown when business rules are broken.
        /// </exception>
        private static void ThrowExceptionIfDeliveryAddressIsInvalid(DeliveryAddress address)
        {
            if (address.GetBrokenRules().Any())
            {
                var addressIssues = new StringBuilder();
                addressIssues.AppendLine("There were some issues with the delivery address you are adding or editing.");

                foreach (var rule in address.GetBrokenRules())
                {
                    addressIssues.AppendLine(rule.Rule);
                }

                throw new InvalidDeliveryAddressException(addressIssues.ToString());
            }
        }
    }
}