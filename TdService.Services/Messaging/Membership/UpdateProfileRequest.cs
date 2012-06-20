// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateProfileRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Update profile request DTO.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    using TdService.Model.Notification;
    using TdService.Services.Messaging;

    /// <summary>
    /// Update profile request DTO.
    /// </summary>
    public class UpdateProfileRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Notification Rule.
        /// </summary>
        public NotificationRule NotificationRule { get; set; }
    }
}