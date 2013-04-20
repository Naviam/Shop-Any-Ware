// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangePasswordRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The change password request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    using System;

    /// <summary>
    /// The change password request.
    /// </summary>
    public class ChangePasswordRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password reset key.
        /// </summary>
        public Guid PasswordResetKey { get; set; }
    }
}
