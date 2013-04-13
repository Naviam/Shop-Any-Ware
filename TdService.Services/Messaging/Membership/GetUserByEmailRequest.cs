// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUserByEmailRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get user by email request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The get user by email request.
    /// </summary>
    public class GetUserByEmailRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
    }
}
