// -----------------------------------------------------------------------
// <copyright file="DeliveryAddressService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System.Linq;
    using System.Text;

    using TdService.Model.Addresses;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Address;
    using TdService.Services.ViewModels.Account;

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
            var response = new GetDeliveryAddressesResponse { DeliveryAddressesView = new DeliveryAddressesView() };
            response.DeliveryAddressesView.DeliveryAddressBook =
                this.addressRepository.GetDeliveryAddresses(request.Email);
            return response;
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
        public AddDeliveryAddressResponse AddDeliveryAddress(AddDeliveryAddressRequest request)
        {
            var response = new AddDeliveryAddressResponse();
            var deliveryAddress = new DeliveryAddress
                {
                    Id = 0,
                    FirstName = request.DeliveryAddressDetails.FirstName,
                    LastName = request.DeliveryAddressDetails.LastName,
                    AddressName = request.DeliveryAddressDetails.AddressName,
                    Region = request.DeliveryAddressDetails.Region,
                    Phone = request.DeliveryAddressDetails.Phone,
                    State = request.DeliveryAddressDetails.State,
                    City = request.DeliveryAddressDetails.City,
                    Country = request.DeliveryAddressDetails.Country,
                    ZipCode = request.DeliveryAddressDetails.ZipCode,
                    AddressLine1 = request.DeliveryAddressDetails.AddressLine1,
                    AddressLine2 = request.DeliveryAddressDetails.AddressLine2,
                    AddressLine3 = request.DeliveryAddressDetails.AddressLine3
                };

            ThrowExceptionIfDeliveryAddressIsInvalid(deliveryAddress);

            this.addressRepository.AddOrUpdateDeliveryAddress(request.Email, deliveryAddress);

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