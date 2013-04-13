// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUserByIdRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get user by id request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The get user by id request.
    /// </summary>
    public class GetUserByIdRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }
    }
}
