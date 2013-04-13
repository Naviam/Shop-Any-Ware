// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUsersPackagesResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get users packages response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    using System.Collections.Generic;

    /// <summary>
    /// The get users packages response.
    /// </summary>
    public class GetUsersPackagesResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the users packages.
        /// </summary>
        public List<UserPackageResponse> UsersPackages { get; set; }
    }
}
