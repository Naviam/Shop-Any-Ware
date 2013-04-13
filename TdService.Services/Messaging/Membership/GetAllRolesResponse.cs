// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllRolesResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get all roles response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The get all roles response.
    /// </summary>
    public class GetAllRolesResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string Name { get; set; }
    }
}
