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
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Current Password.
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        [Required]
        public string LastName { get; set; }
    }
}