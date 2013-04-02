// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewAdminUser.cs" company="Naviam">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The new admin user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Admin
{
    /// <summary>
    /// The new admin user.
    /// </summary>
    public class NewAdminUser
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
        /// Gets or sets a value indicating whether is admin.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is operator.
        /// </summary>
        public bool IsOperator { get; set; }
    }
}
