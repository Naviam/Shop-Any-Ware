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
        /// Gets or sets Notification Rules.
        /// </summary>
        public NotificationRules NotificationRules { get; set; }

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