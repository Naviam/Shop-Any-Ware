// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUsersInRoleRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get users in role request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The get users in role request.
    /// </summary>
    public class GetUsersInRoleRequest
    {
        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the skip.
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Gets or sets the take.
        /// </summary>
        public int Take { get; set; }
    }
}
