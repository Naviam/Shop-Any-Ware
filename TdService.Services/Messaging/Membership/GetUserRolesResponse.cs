// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUserRolesResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The get user roles response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The get user roles response.
    /// </summary>
    public class GetUserRolesResponse : ResponseBase
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