// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUserResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get user response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership.Base
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The get user response.
    /// </summary>
    public abstract class GetUserResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the orders count.
        /// </summary>
        public int OrdersCount { get; set; }

        /// <summary>
        /// Gets or sets the packages count.
        /// </summary>
        public int PackagesCount { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the last access date.
        /// </summary>
        public DateTime? LastAccessDate { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public List<int> Roles { get; set; }
    }
}
