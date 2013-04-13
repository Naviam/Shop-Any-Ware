// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionsViewModelMapper.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The transactions view model mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;
    using AutoMapper;
    using TdService.Services.Messaging.Transactions;
    using TdService.UI.Web.ViewModels.Ballance;

    /// <summary>
    /// The transactions view model mapper.
    /// </summary>
    public static class TransactionsViewModelMapper
    {
        /// <summary>
        /// Convert list of get transactions responses to list of transaction view models.
        /// </summary>
        /// <param name="responses">
        /// The list of get transaction responses.
        /// </param>
        /// <returns>
        /// The list of transaction view models.
        /// </returns>
        public static List<TransactionsViewModel> ConvertToTransactionsViewModelCollection(this List<GetTransactionsResponse> responses)
        {
            var result = Mapper.Map<List<GetTransactionsResponse>, List<TransactionsViewModel>>(responses);
            return result;
        }

        /// <summary>
        /// Convert transaction view model to add transaction request message.
        /// </summary>
        /// <param name="model">
        /// The transaction view model.
        /// </param>
        /// <returns>
        /// The add transaction request message.
        /// </returns>
        public static AddTransactionRequest ConvertToAddTransactionRequest(this TransactionsViewModel model)
        {
            return Mapper.Map<TransactionsViewModel, AddTransactionRequest>(model);
        }

        /// <summary>
        /// The convert to transaction view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="TransactionsViewModel"/>.
        /// </returns>
        public static TransactionsViewModel ConvertToTransactionViewModel(this AddTransactionResponse response)
        {
            return Mapper.Map<AddTransactionResponse, TransactionsViewModel>(response);
        }
    }
}
