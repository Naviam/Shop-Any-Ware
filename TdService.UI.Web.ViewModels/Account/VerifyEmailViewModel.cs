// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerifyEmailViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The verify email view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    /// <summary>
    /// The verify email view model.
    /// </summary>
    public class VerifyEmailViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether email exists.
        /// </summary>
        public bool EmailExists { get; set; }
    }
}