// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUsersInRoleResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get users in role response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The get users in role response.
    /// </summary>
    public class GetUsersInRoleResponse
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public List<UserResponse> Users { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
