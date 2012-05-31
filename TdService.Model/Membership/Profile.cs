// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Profile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Notification;

    /// <summary>
    /// User profile.
    /// </summary>
    public class Profile : EntityBase<int>
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

        /// <summary>
        /// Gets or sets Row Version.
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not implemented yet
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}