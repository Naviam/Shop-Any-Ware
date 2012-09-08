namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Address;
    using TdService.UI.Web.ViewModels.Account;

    public static class DeliveryAddressViewModelMapping
    {
        /// <summary>
        /// Convert delivery address view model to add delivery address request.
        /// </summary>
        /// <param name="model">
        /// The delivery address view model.
        /// </param>
        /// <returns>
        /// The add delivery address request.
        /// </returns>
        public static AddOrUpdateDeliveryAddressRequest ConvertToAddDeliveryAddressRequest(this DeliveryAddressViewModel model)
        {
            return Mapper.Map<DeliveryAddressViewModel, AddOrUpdateDeliveryAddressRequest>(model);
        }

        public static List<DeliveryAddressViewModel> ConvertToDeliveryAddressViewModel(this List<GetDeliveryAddressesResponse> responses)
        {
            return Mapper.Map<List<GetDeliveryAddressesResponse>, List<DeliveryAddressViewModel>>(responses);
        }

        public static DeliveryAddressViewModel ConvertToDeliveryAddressViewModel(this AddOrUpdateDeliveryAddressResponse response)
        {
            return Mapper.Map<AddOrUpdateDeliveryAddressResponse, DeliveryAddressViewModel>(response);
        }

        public static DeliveryAddressViewModel ConvertToDeliveryAddressViewModel(this RemoveDeliveryRequestResponse response)
        {
            return Mapper.Map<RemoveDeliveryRequestResponse, DeliveryAddressViewModel>(response);
        }
    }
}