namespace TdService.UI.Web.Mapping
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using TdService.Services.Messaging.Transactions;
    using TdService.UI.Web.ViewModels.Ballance;

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
            var result =  Mapper.Map<List<GetTransactionsResponse>, List<TransactionsViewModel>>(responses);
            return result;
        }
    }
}
