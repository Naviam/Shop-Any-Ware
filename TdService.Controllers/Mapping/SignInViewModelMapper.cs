// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInViewModelMapper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The sign in view model mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The sign in view model mapper.
    /// </summary>
    public static class SignInViewModelMapper
    {
        /// <summary>
        /// The convert to sign in request.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Membership.SignInRequest.
        /// </returns>
        public static SignInRequest ConvertToSignInRequest(this SignInViewModel model)
        {
            return Mapper.Map<SignInViewModel, SignInRequest>(model);
        }

        /// <summary>
        /// The convert to sign in view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Account.SignInViewModel.
        /// </returns>
        public static SignInViewModel ConvertToSignInViewModel(this SignInResponse response)
        {
            return Mapper.Map<SignInResponse, SignInViewModel>(response);
        }
    }
}