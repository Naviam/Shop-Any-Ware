// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignUpViewModelMapper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The sign up view model mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The sign up view model mapper.
    /// </summary>
    public static class SignUpViewModelMapper
    {
        /// <summary>
        /// The convert to sign up view model.
        /// </summary>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The TdService.UI.Web.ViewModels.Account.SignUpViewModel.
        /// </returns>
        public static SignUpViewModel ConvertToSignUpViewModel(this SignUpResponse response)
        {
            return Mapper.Map<SignUpResponse, SignUpViewModel>(response);
        }
    }
}
