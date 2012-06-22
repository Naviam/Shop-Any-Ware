// -----------------------------------------------------------------------
// <copyright file="ProfileView.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessageResourceName = "RequiredFirstName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(64, ErrorMessageResourceName = "MaxLengthFirstName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        [Required(ErrorMessageResourceName = "RequiredLastName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
        [StringLength(64, ErrorMessageResourceName = "MaxLengthLastName", ErrorMessageResourceType = typeof(Resources.ErrorCodeResources))]
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