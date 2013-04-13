// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActivateUserEmailRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The activate user email request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    using System;

    /// <summary>
    /// The activate user email request.
    /// </summary>
    public class ActivateUserEmailRequest
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the activation code.
        /// </summary>
        public Guid ActivationCode { get; set; }
    }
}
