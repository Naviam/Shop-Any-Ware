// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WelcomeViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The welcome view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Member
{
    /// <summary>
    /// The welcome view model.
    /// </summary>
    public class WelcomeViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
    }
}
