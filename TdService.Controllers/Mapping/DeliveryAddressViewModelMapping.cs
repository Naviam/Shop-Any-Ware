// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAddressViewModelMapping.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The delivery address view model mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using TdService.Services.Messaging.Address;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The delivery address view model mapping.
    /// </summary>
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
        public static AddOrUpdateDeliveryAddressRequest ConvertToAddDeliveryAddressRequest(
            this DeliveryAddressViewModel model)
        {
            return Mapper.Map<DeliveryAddressViewModel, AddOrUpdateDeliveryAddressRequest>(model);
        }

        /// <summary>
        /// The convert to delivery address view model.
        /// </summary>
        /// <param name="responses">
        /// The responses.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.UI.Web.ViewModels.Account.DeliveryAddressViewModel].
        /// </returns>
        public static List<DeliveryAddressViewModel> ConvertToDeliveryAddressViewModel(
            this List<GetDeliveryAddressesResponse> responses)
        {
            return Mapper.Map<List<GetDeliveryAddressesResponse>, List<DeliveryAddressViewModel>>(responses);
        }

        /// <summary>
        /// The convert to delivery address view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Account.DeliveryAddressViewModel.
        /// </returns>
        public static DeliveryAddressViewModel ConvertToDeliveryAddressViewModel(
            this AddOrUpdateDeliveryAddressResponse response)
        {
            return Mapper.Map<AddOrUpdateDeliveryAddressResponse, DeliveryAddressViewModel>(response);
        }

        /// <summary>
        /// The convert to delivery address view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Account.DeliveryAddressViewModel.
        /// </returns>
        public static DeliveryAddressViewModel ConvertToDeliveryAddressViewModel(
            this RemoveDeliveryRequestResponse response)
        {
            return Mapper.Map<RemoveDeliveryRequestResponse, DeliveryAddressViewModel>(response);
        }

        /// <summary>
        /// The convert to countries view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The collection of country view models.
        /// </returns>
        public static IEnumerable<CountryViewModel> ConvertToCountriesViewModel(this List<GetCountriesResponse> response)
        {
            var converted = Mapper.Map<List<GetCountriesResponse>, List<CountryViewModel>>(response).OrderBy(vm => vm.TranslatedName).ToList();
            converted.Where(vm => new int[] { 176, 221, 20 }.Contains(vm.Id)).ToArray().Each(
                vm =>
                {
                    converted.Remove(vm);
                    converted.Insert(0, vm);
                });
            return converted;
        }
    }
}