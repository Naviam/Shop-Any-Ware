// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleViewModelMapper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The role view model mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The role view model mapper.
    /// </summary>
    public static class RoleViewModelMapper
    {
        /// <summary>
        /// The convert to get user roles response collection.
        /// </summary>
        /// <param name="responses">
        /// The responses.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.UI.Web.ViewModels.Account.RoleViewModel].
        /// </returns>
        public static List<RoleViewModel> ConvertToRoleViewModelCollection(this List<GetUserRolesResponse> responses)
        {
            return Mapper.Map<List<GetUserRolesResponse>, List<RoleViewModel>>(responses);
        }
    }
}
