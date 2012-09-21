// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShopperDashboardViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The shopper dashboard view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Member
{
    /// <summary>
    /// The shopper dashboard view model.
    /// </summary>
    public class ShopperDashboardViewModel : ViewModelBase
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