// -----------------------------------------------------------------------
// <copyright file="UpdateProfileResponse.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// Update profile response.
    /// </summary>
    public class UpdateProfileResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notify on order status changed.
        /// </summary>
        public bool NotifyOnOrderStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notify on package status changed.
        /// </summary>
        public bool NotifyOnPackageStatusChanged { get; set; }
    }
}