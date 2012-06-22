// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetProfileResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the get profile request object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// Get profile response object.
    /// </summary>
    public class GetProfileResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Current Password.
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether NotifyOnOrderStatusChange.
        /// </summary>
        public bool NotifyOnOrderStatusChange { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether NotifyOnPackageStatusChange.
        /// </summary>
        public bool NotifyOnPackageStatusChange { get; set; }
    }
}