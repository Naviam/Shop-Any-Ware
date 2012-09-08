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
        public static AddDeliveryAddressRequest ConvertToAddDeliveryAddressRequest(this DeliveryAddressViewModel model)
        {
            return Mapper.Map<DeliveryAddressViewModel, AddDeliveryAddressRequest>(model);
        }

        public static List<DeliveryAddressViewModel> ConvertToDeliveryAddressViewModel(this List<GetDeliveryAddressesResponse> responses)
        {
            return Mapper.Map<List<GetDeliveryAddressesResponse>, List<DeliveryAddressViewModel>>(responses);
        }
    }
}