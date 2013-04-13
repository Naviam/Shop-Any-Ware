// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddUserToRoleRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The add user to role request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The add user to role request.
    /// </summary>
    public class AddUserToRoleRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }
    }
}
