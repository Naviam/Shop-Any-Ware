// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The main view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel
    {
        /// <summary>
        /// Gets or sets the sign in view model.
        /// </summary>
        public SignInViewModel SignInViewModel { get; set; }

        /// <summary>
        /// Gets or sets the sign up view model.
        /// </summary>
        public SignUpViewModel SignUpViewModel { get; set; }
    }
}