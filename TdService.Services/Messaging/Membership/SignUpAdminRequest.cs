// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignUpAdminRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The sign up admin request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The sign up admin request.
    /// </summary>
    public class SignUpAdminRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether admin role.
        /// </summary>
        public bool AdminRole { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether operator role.
        /// </summary>
        public bool OperatorRole { get; set; }
    }
}
