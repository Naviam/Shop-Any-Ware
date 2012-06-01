// -----------------------------------------------------------------------
// <copyright file="ProfileView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.ViewModels.Account
{
    /// <summary>
    /// This is the profile model for web form.
    /// </summary>
    public class ProfileView : BaseView
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Current Password.
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Notify On Order Status Change.
        /// </summary>
        public bool NotifyOnOrderStatusChange { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Notify On Package Status Change.
        /// </summary>
        public bool NotifyOnPackageStatusChange { get; set; }
    }
}