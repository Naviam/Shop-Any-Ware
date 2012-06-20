﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Profile.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the Profile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
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
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.FirstName))
            {
                this.AddBrokenRule(ProfileBusinessRules.FirstNameRequired);
            }

            if (this.FirstName.Length > 64)
            {
                this.AddBrokenRule(ProfileBusinessRules.FirstNameLength);
            }

            if (string.IsNullOrEmpty(this.LastName))
            {
                this.AddBrokenRule(ProfileBusinessRules.LastNameRequired);
            }

            if (this.LastName.Length > 64)
            {
                this.AddBrokenRule(ProfileBusinessRules.LastNameLength);
            }
        }
    }
}